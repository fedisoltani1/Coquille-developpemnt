using Access.AppCore.Models.Ville;
using FluentValidation;

namespace Access.AppCore.Validator
{
    public class VilleValidator : AbstractValidator<VilleModel>
    {
        public VilleValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Le code est obligatoire")
                .MaximumLength(100).WithMessage("Le code ne doit pas dépasser 100 caractères");

            RuleFor(x => x.Intitule)
                .NotEmpty().WithMessage("L'intitulé est obligatoire")
                .MaximumLength(100).WithMessage("L'intitulé ne doit pas dépasser 100 caractères");

           
        }
    }
}
