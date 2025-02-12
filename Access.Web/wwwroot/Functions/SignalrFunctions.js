//Notification windows
function notificationWindows(titre, text, url = null) {
    const img = "../../Logos/logoGsl.png";
    const options = {
        body: text, // Notification body text
        icon: img, // Notification icon
        dir: "auto", // Text direction
        badge: img, // Small monochrome icon
        requireInteraction: true // Notification stays active until user interacts
    };
    const notification = new Notification(titre, options);
    if (url != null) {
        notification.onclick = function (event) {
            event.preventDefault();
            notification.close();
            window.open(url, '_blank');
        };
    }
    setTimeout(() => {
        notification.close();
    }, 5000);
}

//Paramétrage hub
const tagsHubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/TagsHub")
    .configureLogging(signalR.LogLevel.Information)
    .build();

//Function to start communication
async function start() {
    try {
        await tagsHubConnection.start();
        console.log("Connected to TagsHub");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

//When lost connection reconnect to hub
tagsHubConnection.onclose(async () => {
    //await connection.stop();
    await start();
});
tagsHubConnection.start();

//New Rfid Tag Added. Shonw on all pages
tagsHubConnection.on("ReceiveNotificationAssociationTag", (message, articleId) => {
    var audio = new Audio('../../Sounds/NotificationSoundTag.wav');
    audio.play();
    notificationSuccess(message);
    notificationWindows("Nouveau Tag Rfid", message, window.location.origin + "/Articles/ArticleTags/" + articleId);
});

//Clôture inventaire
tagsHubConnection.on("ReceiveNotificationClotureInventaire", (message) => {
    var audio = new Audio('../../Sounds/NotificationSoundTag.wav');
    audio.play();
    notificationSuccess("Inventaire clôturé par " + message);
    notificationWindows("Clôture inventaire", "Inventaire clôturé par " + message);
});

//Test message multi user
$("#sendButton").on('click', function () {
    var message = $("#messageBox").val();
    var userId = $("#userIdBox").val();
    tagsHubConnection.invoke("SendMessageToUserTest", message, userId);
});

//Receive message function
tagsHubConnection.on("ReceiveMessage", (message) => {
    const li = document.createElement("li");
    li.textContent = `${message}`;
    document.getElementById("messageList2").appendChild(li);
    var audio = new Audio('../../Sounds/NotificationSoundTag.wav');
    audio.play();
    notificationSuccess(message);
    notificationWindows("Message reçu", message);
});