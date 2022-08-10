using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KullaniciController : Controller
    {
        KullaniciValidator kullaniciValidator = new KullaniciValidator();
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici kullanici)
        {
            kullanici.YetkiId = 2;
            ValidationResult results = kullaniciValidator.Validate(kullanici);

            

            if (results.IsValid)
            {

                kullaniciManager.Add(kullanici);
                return RedirectToAction("Index", "Anasayfa");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
           
        }
    }
}
