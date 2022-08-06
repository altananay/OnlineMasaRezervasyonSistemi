using Entity.Concrete;
using Entity.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules
{
    public class RandevuValidator : AbstractValidator<RandevuKayit>
    {
        public RandevuValidator()
        {
            RuleFor(rk => rk.BaslangicTarihi).NotEmpty().WithMessage("Baslangic tarihi bos olamaz");
            RuleFor(rk => rk.BaslangicSaati).NotEmpty().WithMessage("baslangic saati bos olamaz");
            RuleFor(rk => rk.BitisTarihi).NotEmpty().WithMessage("Bitis tarihi bos olamaz");
            RuleFor(rk => rk.BitisSaati).NotEmpty().WithMessage("bitis saati bos olamaz");
            RuleFor(rk => rk.MasaId).NotEmpty().WithMessage("Masa seçiniz");
        }
    }
}
