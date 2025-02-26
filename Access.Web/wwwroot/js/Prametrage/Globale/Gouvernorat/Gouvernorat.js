$(document).ready(function () {
    $('#Upsert').submit(function (event) {
        event.preventDefault();


        if (this.checkValidity()) {

            ResponseForm(
                "POST",                   // HTTP method
                "Gouvernorat",                // Controller name
                "CreateOrUpdate",                 // Action name
                "/Gouvernorat/Index",                     // No additional parameters
                false,                     // Indicates whether to use AJAX
                1000,                     // Timeout (in milliseconds)
                $(this).serialize(),      // Serialized form data
                true,                     // Indicates whether to show loading spinner (optional)
                "btnSubmit"               // The ID of the submit button (for disabling/enabling it)
            );
        } else {

            this.reportValidity();
        }
    });
});

function deleteGouvernorat(id) {
    ResponseDelete("POST", "Gouvernorat", "Delete", null, true, 1000, id, "Voulez-vous supprimer cette gouvernorat ?");
}
function UpdateGouvernorat() {
    $('#Upsert').submit(function (event) {
        event.preventDefault(); // Empêche l'envoi classique du formulaire

        if (this.checkValidity()) { // Si la validation HTML5 est réussie
            ResponseForm("POST", "Gouvernorat", "CreateOrUpdate", "/Gouvernorat/Index", false, 1000, $(this).serialize(), true, "btnSubmit");
        } else {
            this.reportValidity(); // Affiche les erreurs de validation
        }
    });
}



