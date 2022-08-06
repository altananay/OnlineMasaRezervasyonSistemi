using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class DepartmanValidator : AbstractValidator<Departman>
    {
        public DepartmanValidator()
        {
            RuleFor(d => d.DepartmanAdi).NotEmpty().WithMessage("Departman adı boş olamaz");
        }
    }
}
