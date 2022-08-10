using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class KullaniciValidator : AbstractValidator<Kullanici>
    {
        public KullaniciValidator()
        {
            RuleFor(k => k.Ad).NotEmpty().WithMessage("Ad boş geçilemez");
            RuleFor(k => k.Soyad).NotEmpty().WithMessage("Soyad boş geçilemez");
            RuleFor(k => k.Eposta).NotEmpty().WithMessage("Eposta boş geçilemez");
            RuleFor(k => k.Eposta).EmailAddress().WithMessage("Eposta email formatında olmalı");
            RuleFor(k => k.Eposta).EmailAddress().Matches("@fmc-ag.com").WithMessage("Eposta doğru formatta olmalı");
            RuleFor(k => k.Gorev).NotEmpty().WithMessage("Gorev boş olamaz");
            RuleFor(k => k.DepartmanId).NotEmpty().WithMessage("Departman bilgisi boş geçilemez");
        }
    }
}
