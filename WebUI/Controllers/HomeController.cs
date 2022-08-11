using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        RandevuKayitManager randevuKayitManager = new RandevuKayitManager(new EfRandevuKayitDal());
        LoginValidator loginValidator = new LoginValidator();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string Eposta)
        {
            Kullanici kullanici = new Kullanici();
            kullanici.Eposta = Eposta;
            ValidationResult results = loginValidator.Validate(kullanici);
            if (results.IsValid)
            {
                var values = kullaniciManager.GetByEmail(Eposta);
                kullanici = values;

                var values2 = randevuKayitManager.GetAllById(kullanici.KullaniciId);

                foreach (var item in values2)
                {
                    if (item.BitisTarihi < DateTime.Now)
                    {
                        item.DurumId = 1;
                        randevuKayitManager.Update(item);
                    }
                }

                if (values != null)
                {
                    return RedirectToAction("Index", "Profile", kullanici);
                }
                else
                {
                    return RedirectToAction("KullaniciEkle", "Kullanici");
                }
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}