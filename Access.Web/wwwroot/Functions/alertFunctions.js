//Notification success
function notificationSuccess(message, timer = 1500) {
    Swal.fire({
        position: "top-end",
        text: message,
        icon: 'success',
        showConfirmButton: false,
        timer: timer,
        customClass: {
            popup: 'sweetAlertNotificationGlobal',
            title: 'sweetAlertNotificationTitle',
            content: 'sweetAlertNotificationContent',
            icon: 'sweetAlertNotificationIcon'
        },
        width: '25rem'
    });
}

//Notification warning
function notificationWarning(message, timer = 2500) {
    Swal.fire({
        position: "top-end",
        text: message,
        icon: 'warning',
        showConfirmButton: false,
        timer: timer,
        customClass: {
            popup: 'sweetAlertNotificationGlobal',
            title: 'sweetAlertNotificationTitle',
            content: 'sweetAlertNotificationContent',
            icon: 'sweetAlertNotificationIcon'
        },
        width: '25rem'
    });
}

//Notification info
function notificationInfo(message, timer = 2000) {
    Swal.fire({
        position: "top-end",
        text: message,
        icon: 'info',
        showConfirmButton: false,
        timer: timer,
        customClass: {
            popup: 'sweetAlertNotificationGlobal',
            title: 'sweetAlertNotificationTitle',
            content: 'sweetAlertNotificationContent',
            icon: 'sweetAlertNotificationIcon'
        },
        width: '25rem'
    });
}

//Notification error
function notificationError(message, timer = 2500) {
    Swal.fire({
        position: "top-end",
        //title: 'Attention',
        text: message,
        icon: 'error',
        showConfirmButton: false,
        timer: timer,
        customClass: {
            popup: 'sweetAlertNotificationGlobal',
            title: 'sweetAlertNotificationTitle',
            content: 'sweetAlertNotificationContent',
            icon: 'sweetAlertNotificationIcon'
        },
        width: '25rem'
    });
}

//Show loader
function blocageUi() {
    $.blockUI({
        message: '<svg width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-loader"><line x1="12" y1="2" x2="12" y2="6"></line><line x1="12" y1="18" x2="12" y2="22"></line><line x1="4.93" y1="4.93" x2="7.76" y2="7.76"></line><line x1="16.24" y1="16.24" x2="19.07" y2="19.07"></line><line x1="2" y1="12" x2="6" y2="12"></line><line x1="18" y1="12" x2="22" y2="12"></line><line x1="4.93" y1="19.07" x2="7.76" y2="16.24"></line><line x1="16.24" y1="7.76" x2="19.07" y2="4.93"></line></svg><br />Chargement ...',
        css: {
            backgroundColor: "transparent",
            border: "0"
        },
        overlayCSS: {
            opacity: 0.5
        }
    });
}

//Hide loader
function deblocageUi() {
    $.unblockUI();
}