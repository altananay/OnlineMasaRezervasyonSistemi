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
        public IActionResult Index(Kullanici kullanici)
        {
            return View(kullanici);
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
                kullaniciManager.Update(kullanici);
                return RedirectToAction("Index", kullanici);
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
