using Access.AppCore.Models.Cite;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Access.AppCore.Validator
{
    public class CiteValidator : AbstractValidator<CiteModel>
    {
        public CiteValidator()
        {
            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Le code est requis")
                .MaximumLength(100).WithMessage("Le code ne doit pas dépasser 100 caractères");

            RuleFor(x => x.Intitule)
                .NotEmpty().WithMessage("L'intitulé est requis")
                .MaximumLength(100).WithMessage("L'intitulé ne doit pas dépasser 100 caractères");

        }
    }
}
