using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class RandevuController : Controller
    {
        RandevuKayitManager randevuKayitManager = new RandevuKayitManager(new EfRandevuKayitDal());
        RandevuKatilimcisiManager randevuKatilimcisiManager = new RandevuKatilimcisiManager(new EfRandevuKatilimcisiDal());
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        RandevuValidator randevuValidator = new RandevuValidator();

        //parametre olarak gelen modeli, model state ile beraber aldı.
        public IActionResult Index(RandevuKayit randevuKayit)
        {
            return View(randevuKayit);
        }

        public IActionResult RandevuSil(int id)
        {
            var values = randevuKayitManager.GetById(id);
            randevuKayitManager.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult RandevuEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RandevuEkle(RandevuKayit randevuKayit, int[] ids)
        {
            ValidationResult validationResult = randevuValidator.Validate(randevuKayit);
            if (validationResult.IsValid)
            {
                randevuKayit.KullaniciId = 2;
                randevuKayit.DurumId = 1;
                randevuKayit.KayitTarihi = DateTime.Now;
                randevuKayitManager.Add(randevuKayit);

                var id = randevuKayit.RandevuId;

                for (int i = 0; i < ids.Length; i++)
                {
                    RandevuKatilimcisi randevuKatilimcisi = new RandevuKatilimcisi();
                    randevuKatilimcisi.KullaniciId = ids[i];
                    randevuKatilimcisi.RandevuId = id;
                    randevuKatilimcisi.Aktif = true;
                    randevuKatilimcisiManager.Add(randevuKatilimcisi);
                }



                return Json(new {success = true});
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            //ModelState'ini RandevuEkle controller'ından Index controller'ına parametre olarak yolladık
            //View return ederken tam yolu verilmeli. Sadece View'in ismi verilirse model state'i gitmez.
            //return View("~/Views/Randevu/Index.cshtml", randevuKayit);
            return Json(new { success = false });
        }
    }
}
