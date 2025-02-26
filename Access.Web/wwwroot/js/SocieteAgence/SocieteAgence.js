$(document).ready(function () {
    $('#CreateForm').submit(function (event) {
        event.preventDefault();

        if (this.checkValidity()) {
            ResponseForm(
                "POST",
                "SocieteAgence",
                "Create",
                "/SocieteAgence/Index",
                false,
                1000,
                $(this).serialize(),
                true,
                "btnSubmit"
            );
        } else {
            this.reportValidity();
        }
    });

    $('#UpdateForm').submit(function (event) {
        event.preventDefault();

        if (this.checkValidity()) {
            ResponseForm(
                "POST",
                "SocieteAgence",
                "Update",
                "/SocieteAgence/Index",
                false,
                1000,
                $(this).serialize(),
                true,
                "btnSubmit"
            );
        } else {
            this.reportValidity();
        }
    });
});

function deleteAgence(id) {
    ResponseDelete(
        "POST",
        "SocieteAgence",
        "Delete",
        null,
        true,
        1000,
        id,
        "Voulez-vous supprimer cette agence ?"
    );
}
