$(document).ready(function () {
    $('#UpdateForm').submit(function (event) {
        event.preventDefault();


        if (this.checkValidity()) {

            ResponseForm(
                "POST",                   // HTTP method
                "Societe",                // Controller name
                "Update",                 // Action name
                null,                     // No additional parameters
                true,                     // Indicates whether to use AJAX
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


