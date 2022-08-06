using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KullaniciAdminController : Controller
    {
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        KullaniciValidator kullaniciValidator = new KullaniciValidator();
        public IActionResult Index()
        {
            var values = kullaniciManager.GetKullaniciDto();
            return View(values);
        }

        public IActionResult KullaniciSil(int id)
        {
            var values = kullaniciManager.GetById(id);
            values.Aktif = false;
            kullaniciManager.Update(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult KullaniciEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici kullanici)
        {
            ValidationResult validationResult = kullaniciValidator.Validate(kullanici);
            if (validationResult.IsValid)
            {
                kullanici.YetkiId = kullanici.YetkiId;
                kullaniciManager.Add(kullanici);
                return RedirectToAction("Index");
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
                return RedirectToAction("Index");
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

        public IActionResult AktifOlmayanKullanicilar()
        {
            var values = kullaniciManager.GetAllByInactive();
            return View(values);
        }
    }
}
