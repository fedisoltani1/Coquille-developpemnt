//Function for ajax standard
function ResponseForm(methode, controller, action, locationPath, isReload = false, timer, data, blocage = true, buttonId = null) {
    if (buttonId != null) {
        document.getElementById(buttonId).disabled = true;
    }
    $.ajax({
        type: methode,
        url: '/' + controller + '/' + action,
        data: data,
        beforeSend: function () {
            if (blocage)
                blocageUi();
        },
        complete: function () {
            if (blocage)
                deblocageUi();
        },
        success: function (response) {
            if (response.IsSuccess == true) {
                notificationSuccess(response.Message);
                if (locationPath != null) {
                    setTimeout(function () {
                        location.href = locationPath;
                    }, timer);
                }
                if (isReload) {
                    setTimeout(function () {
                        location.reload();
                    }, timer);
                }
                if (buttonId != null) {
                    document.getElementById(buttonId).disabled = false;
                }
            } else {
                notificationWarning(response.Message);
                if (buttonId != null) {
                    document.getElementById(buttonId).disabled = false;
                }
            }
        },
        error: function (xhr, status, error) {
            notificationError("Fonctionnalité introuvable !");
            if (buttonId != null) {
                document.getElementById(buttonId).disabled = false;
            }
        }
    });
}

//Login Function ajax
function ResponseLogin(methode, controller, action, data, buttonId) {
    if (buttonId != null) {
        document.getElementById(buttonId).disabled = true;
    }
    $.ajax({
        type: methode,
        url: '/' + controller + '/' + action,
        data: data,
        beforeSend: function () {
            blocageUi();
        },
        complete: function () {
            deblocageUi();
        },
        success: function (response) {
            if (response.IsSuccess == true) {
                notificationSuccess(response.Message);
                setTimeout(function () {
                    location.href = response.Data;
                }, 1500);
            } else {
                notificationWarning(response.Message);
                document.getElementById(buttonId).disabled = false;
            }
        },
        error: function (xhr, status, error) {
            notificationError("Serveur introuvable !");
            document.getElementById(buttonId).disabled = false;
        }
    });
}

//Function for delete with confirmation
function ResponseDelete(methode, controller, action, locationPath, isReload = false, timer, data, message) {
    Swal.fire({
        title: message,
        text: "Vous ne pourrez pas annuler cela !",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Oui, supprimer",
        cancelButtonText: "Non",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: methode,
                url: '/' + controller + '/' + action,
                data: { 'id': data },
                beforeSend: function () {
                    blocageUi();
                },
                complete: function () {
                    deblocageUi();
                },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        notificationSuccess(response.Message);
                        if (locationPath != null) {
                            setTimeout(function () {
                                location.href = locationPath;
                            }, timer);
                        }
                        if (isReload) {
                            setTimeout(function () {
                                location.reload();
                            }, timer);
                        }
                    } else {
                        notificationWarning(response.Message);
                    }
                },
                error: function (xhr, status, error) {
                    notificationError("Fonctionnalité introuvable !");
                }
            });
        }
    });
}

//Function for send Id only with message validation
function ResponseValidation(methode, controller, action, locationPath, isReload = false, timer, data, message) {
    Swal.fire({
        title: message,
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Oui",
        cancelButtonText: "Non",
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: methode,
                url: '/' + controller + '/' + action,
                data: { 'id': data },
                beforeSend: function () {
                    blocageUi();
                },
                complete: function () {
                    deblocageUi();
                },
                success: function (response) {
                    if (response.IsSuccess == true) {
                        notificationSuccess(response.Message);
                        if (locationPath != null) {
                            setTimeout(function () {
                                location.href = locationPath;
                            }, timer);
                        }
                        if (isReload) {
                            setTimeout(function () {
                                location.reload();
                            }, timer);
                        }
                    } else {
                        notificationWarning(response.Message);
                    }
                },
                error: function (xhr, status, error) {
                    notificationError("Fonctionnalité introuvable !");
                }
            });
        }
    });
}