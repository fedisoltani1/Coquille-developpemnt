$(document).ready(function () {
    addGouvernorat();
    addVille();
    addCite();
    updateGouvernorat();
    updateVille();
    updateCite();
});

function showPopupAddVille() {
    var modalElement = document.getElementById("addVille");
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}


function showPopupAddGouv() {
    var modalElement = document.getElementById("addGouv");
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}
function showPopupAddCite() {
    var modalElement = document.getElementById("addCite");
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}

function addGouvernorat() {
    $('#CreateGouv').submit(function (event) {
        event.preventDefault();
        if (this.checkValidity()) {
            ResponseForm("POST", "Localisation", "AjouterGouvernorat", null, true, 1000, $(this).serialize(), true, "btnAddItem");
        }
    });
}
function addVille() {
    $('#CreateVille').submit(function (event) {
        event.preventDefault();
        if (this.checkValidity()) {
            ResponseForm("POST", "Localisation", "AjouterVille", null, true, 1000, $(this).serialize(), true, "btnAddVilleItem");
        }
    });
}

function addCite() {
    $('#CreateCite').submit(function (event) {
        event.preventDefault(); 
        if (this.checkValidity()) {
            ResponseForm("POST", "Localisation", "AjouterCite", null, true, 1000, $(this).serialize(), true, "btnAddCiteItem");
        }
    });
}
function showPopupEditGouv(id, code, intitule) {
    $("#editGouvId").val(id);
    $("#editGouvCode").val(code);
    $("#editGouvIntitule").val(intitule);

    var modalElement = document.getElementById("editGouv");
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}


function showPopupEditVille(id, code, intitule, gouvernoratId) {
    $("#editVilleId").val(id);
    $("#editVilleCode").val(code);
    $("#editVilleIntitule").val(intitule);
    $("#editGouvernoratId").val(gouvernoratId); 
   

    var modalElement = document.getElementById("editVille");
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}

function showPopupEditCite(id, code, intitule, gouvernoratId, villeId) {
    $("#editCiteId").val(id);
    $("#editCiteCode").val(code);
    $("#editCiteIntitule").val(intitule);
    $("#editGouvernoratId").val(gouvernoratId);
    $("#editVilleId").val(villeId);


    var modalElement = document.getElementById("editCite");
    var modal = new bootstrap.Modal(modalElement);
    modal.show();
}

function updateGouvernorat() {
    $('#EditGouv').submit(function (event) {
        event.preventDefault();
        if (this.checkValidity()) {
            ResponseForm("POST", "Localisation", "ModifierGouvernorat", null, true, 1000, $(this).serialize(), true, "btnEditGouv");
        }
    });
}
function updateVille() {
    $('#EditVille').submit(function (event) {
        event.preventDefault();
        if (this.checkValidity()) {
            ResponseForm("POST", "Localisation", "ModifierVille", null, true, 1000, $(this).serialize(), true, "btnEditVille");
        }
    });
}

function updateCite() {
    $('#EditCite').submit(function (event) {
        event.preventDefault();
        if (this.checkValidity()) {
            ResponseForm("POST", "Localisation", "ModifierCite", null, true, 1000, $(this).serialize(), true, "btnEditCite");
        }
    });
}

function deleteGouvernorat(id) {
    ResponseDelete("POST", "Localisation", "SupprimerGouvernorat", "/Localisation/Index", false, 1000, id, "Voulez-vous supprimer cette gouvernorat ?");
}


function deleteVille(id) {
    ResponseDelete("POST", "Localisation", "SupprimerVille", "/Localisation/Index", false, 1000, id, "Voulez-vous supprimer cette ville ?");
}




function deleteCite(id) {
    ResponseDelete("POST", "Localisation", "SupprimerCite", "/Localisation/Index", false, 1000, id, "Voulez-vous supprimer cette cite ?");
}

