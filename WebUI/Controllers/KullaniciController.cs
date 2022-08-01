using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KullaniciController : Controller
    {
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
            kullaniciManager.Add(kullanici);
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}
