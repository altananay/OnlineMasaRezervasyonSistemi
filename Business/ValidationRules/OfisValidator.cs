using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class OfisValidator : AbstractValidator<Ofis>
    {
        public OfisValidator()
        {
            RuleFor(o => o.OfisAdi).NotEmpty().WithMessage("Ofis adı boş olamaz");
        }
    }
}
