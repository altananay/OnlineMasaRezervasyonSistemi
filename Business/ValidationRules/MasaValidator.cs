using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class MasaValidator : AbstractValidator<Masa>
    {
        public MasaValidator()
        {
            RuleFor(m => m.MasaAdi).NotEmpty().WithMessage("Masa adi boş olamaz");
            RuleFor(m => m.MasaKodu).NotEmpty().WithMessage("Masa kodu boş olamaz");
            RuleFor(m => m.OfisId).NotEmpty().WithMessage("Ofis boş olamaz");
        }
    }
}
