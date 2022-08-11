using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class ProfileController : Controller
    {
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        KullaniciValidator kullaniciValidator = new KullaniciValidator();
        RandevuKayitManager randevuKayitManager = new RandevuKayitManager(new EfRandevuKayitDal());

        public IActionResult Index(Kullanici kullanici)
        {
            var values = kullaniciManager.GetKullaniciDtoById(kullanici.KullaniciId);
            return View(values);
        }

        public IActionResult RandevuDurumGuncelle(int RandevuId, int durumId)
        {
            var values = randevuKayitManager.GetById(RandevuId);
            values.DurumId = durumId;
            randevuKayitManager.Update(values);
            var values2 = kullaniciManager.GetById(values.KullaniciId);
            return RedirectToAction("Index", values2);
        }
        
        public IActionResult KullaniciGuncelle(int id)
        {
            var values = kullaniciManager.GetById(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult KullaniciGuncelle(Kullanici kullanici)
        {
            ValidationResult validationResult = kullaniciValidator.Validate(kullanici);
            if (validationResult.IsValid)
            {
                kullanici.YetkiId = 2;
                kullanici.Aktif = true;
                kullaniciManager.Update(kullanici);
                var values = kullaniciManager.GetKullaniciDtoById(kullanici.KullaniciId);
                return RedirectToAction("Index", values);
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
