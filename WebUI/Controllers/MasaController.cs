using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MasaController : Controller
    {
        MasaManager masaManager = new MasaManager(new EfMasaDal());

        public IActionResult Index()
        {
            var values = masaManager.GetMasaDto();
            return View(values);
        }

        public IActionResult MasaSil(int id)
        {
            var values = masaManager.GetById(id);
            masaManager.Delete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult MasaEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MasaEkle(Masa masa)
        {
            masaManager.Add(masa);
            return RedirectToAction("Index");
        }

        public IActionResult MasaGüncelle(int id)
        {
            var values = masaManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult MasaGüncelle(Masa masa)
        {
            masaManager.Update(masa);
            return RedirectToAction("Index");
        }
    }
}
