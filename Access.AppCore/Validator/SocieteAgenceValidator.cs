using Access.AppCore.Models.SocieteAgence;
using FluentValidation;

namespace Access.AppCore.Validators
{
    public class SocieteAgenceValidator : AbstractValidator<SocieteAgenceModel>
    {
        public SocieteAgenceValidator()
        {
            RuleFor(x => x.Intitule)
                .NotEmpty().WithMessage("L'intitulé est obligatoire.")
                .MaximumLength(200).WithMessage("L'intitulé ne doit pas dépasser 200 caractères.");

            RuleFor(x => x.Gouvernorat)
                .NotEmpty().WithMessage("Le gouvernorat est obligatoire.")
                .MaximumLength(100).WithMessage("Le gouvernorat ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Ville)
                .NotEmpty().WithMessage("La ville est obligatoire.")
                .MaximumLength(100).WithMessage("La ville ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Adresse)
                .NotEmpty().WithMessage("L'adresse est obligatoire.")
                .MaximumLength(200).WithMessage("L'adresse ne doit pas dépasser 200 caractères.");

            RuleFor(x => x.CodePostal)
                .NotEmpty().WithMessage("Le code postal est obligatoire.")
                .Matches(@"^\d{4,5}$").WithMessage("Le code postal doit être composé de 4 ou 5 chiffres.");

            RuleFor(x => x.Telephone)
                .NotEmpty().WithMessage("Le téléphone est obligatoire.")
                .Matches(@"^\d{8,15}$").WithMessage("Le téléphone doit être composé de 8 à 15 chiffres.");

            RuleFor(x => x.AdresseMail)
                .EmailAddress().WithMessage("L'adresse e-mail n'est pas valide.")
                .MaximumLength(100).WithMessage("L'adresse e-mail ne doit pas dépasser 100 caractères.")
                .When(x => !string.IsNullOrEmpty(x.AdresseMail));

            RuleFor(x => x.ResponsableName)
                 .NotEmpty().WithMessage("Le nom du collaborateur est obligatoire.")
                 .MaximumLength(150).WithMessage("Le nom du collaborateur ne doit pas dépasser 150 caractères.")
                 .Matches(@"^[a-zA-ZÀ-ÿ\s]+$").WithMessage("Le nom du collaborateur ne doit contenir que des lettres.");


            RuleFor(x => x.ResponsableEmail)
                .NotEmpty().WithMessage("L'email du responsable est obligatoire.")
                .MaximumLength(150).WithMessage("L'email ne doit pas dépasser 150 caractères.")
                .EmailAddress().WithMessage("Veuillez entrer une adresse email valide.");

            RuleFor(x => x.ResponsableTel)
              .NotEmpty().WithMessage("Le numéro de téléphone du responsable est obligatoire.")
              .MaximumLength(15).WithMessage("Le numéro de téléphone ne doit pas dépasser 15 caractères.")
              .Matches(@"^[0-9\s]+$").WithMessage("Le numéro de téléphone doit contenir uniquement des chiffres et des espaces.");

            RuleFor(x => x.MatriculeFiscale)
                .MaximumLength(100).WithMessage("Le matricule fiscal ne doit pas dépasser 100 caractères.")
                .When(x => !string.IsNullOrEmpty(x.MatriculeFiscale)); 

            RuleFor(x => x.IsActif)
                .NotNull().WithMessage("Le statut actif est obligatoire.");
        }
    }
}
