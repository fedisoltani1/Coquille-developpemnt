using Access.AppCore.Models.Gouvernorat;
using Access.AppCore.Models.SocieteAgence;
using FluentValidation;

namespace Access.AppCore.Validator
{
    public class GouvernoratValidator : AbstractValidator<GouvernoratModel>
    {
        public GouvernoratValidator()
        {
            RuleFor(x => x.Code)
           .NotEmpty().WithMessage("Le code est obligatoire.")
           .Length(2, 10).WithMessage("Le code doit contenir entre 2 et 10 caractères.");

            // Validation pour Intitule
            RuleFor(x => x.Intitule)
                .NotEmpty().WithMessage("L'intitulé est obligatoire.")
                .Length(2, 100).WithMessage("L'intitulé doit contenir entre 2 et 100 caractères.");
        }
    }
}
