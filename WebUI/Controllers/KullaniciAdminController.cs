using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KullaniciAdminController : Controller
    {
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());

        public IActionResult Index()
        {
            var values = kullaniciManager.GetKullaniciDto();
            return View(values);
        }

        public IActionResult KullaniciSil(int id)
        {
            var values = kullaniciManager.GetById(id);
            kullaniciManager.Delete(values);
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
            kullaniciManager.Add(kullanici);
            return RedirectToAction("Index");
        }

        public IActionResult KullaniciGuncelle(int id)
        {
            var values = kullaniciManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult KullaniciGuncelle(Kullanici kullanici)
        {
            kullaniciManager.Update(kullanici);
            return RedirectToAction("Index");
        }
    }
}
