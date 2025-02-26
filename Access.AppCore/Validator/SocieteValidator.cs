using Access.AppCore.Models.Societe;
using FluentValidation;

namespace Access.AppCore.Validators
{
    public class SocieteValidator : AbstractValidator<SocieteModel>
    {
        public SocieteValidator()
        {
            RuleFor(x => x.RaisonSocial)
                .NotEmpty().WithMessage("La raison sociale est obligatoire.")
                .Length(2, 100).WithMessage("La raison sociale doit contenir entre 2 et 100 caractères.");

            RuleFor(x => x.MatriculeFiscale)
                .NotEmpty().WithMessage("Le matricule fiscal est obligatoire.")
                .MaximumLength(100).WithMessage("Le matricule fiscal ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.RegistreCommerce)
                .MaximumLength(100).WithMessage("Le registre de commerce ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Activite)
                .NotEmpty().WithMessage("L'activité est obligatoire.")
                .MaximumLength(100).WithMessage("L'activité ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.NomCommercial)
                .NotEmpty().WithMessage("Le nom commercial est obligatoire.")
                .MaximumLength(100).WithMessage("Le nom commercial ne doit pas dépasser 100 caractères.");

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

            RuleFor(x => x.AdresseMail)
                .NotEmpty().WithMessage("L'adresse e-mail est obligatoire.")
                .EmailAddress().WithMessage("L'adresse e-mail n'est pas valide.")
                .MaximumLength(100).WithMessage("L'adresse e-mail ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.Telephone)
                .NotEmpty().WithMessage("Le téléphone est obligatoire.")
                .Matches(@"^\d{8,15}$").WithMessage("Le téléphone doit être composé de 8 à 15 chiffres.");

            RuleFor(x => x.Secteur)
                .NotEmpty().WithMessage("Le secteur est obligatoire.")
                .MaximumLength(100).WithMessage("Le secteur ne doit pas dépasser 100 caractères.");

            RuleFor(x => x.PremierResponsable)
                .NotEmpty().WithMessage("Le premier responsable est obligatoire.")
                .MaximumLength(100).WithMessage("Le premier responsable ne doit pas dépasser 100 caractères.");
        }
    }
}
