using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class LoginValidator : AbstractValidator<Kullanici>
    {
        public LoginValidator()
        {
            RuleFor(k => k.Eposta).NotEmpty().WithMessage("Eposta boş geçilemez");
            RuleFor(k => k.Eposta).EmailAddress().Matches("@fmc-ag.com").WithMessage("Eposta doğru formatta olmalı");
        }
    }
}
