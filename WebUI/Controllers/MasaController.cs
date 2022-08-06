using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class MasaController : Controller
    {
        MasaManager masaManager = new MasaManager(new EfMasaDal());
        MasaValidator masaValidator = new MasaValidator();
        public IActionResult Index()
        {
            var values = masaManager.GetMasaDto();
            return View(values);
        }

        public List<Masa> GetByOfisId(int id)
        {
            var values = masaManager.GetByOfisId(id);
            return values;
        }

        public IActionResult MasaSil(int id)
        {
            var values = masaManager.GetById(id);
            values.Aktif = false;
            masaManager.Update(values);
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
            ValidationResult validationResult = masaValidator.Validate(masa);
            if (validationResult.IsValid)
            {
                masaManager.Add(masa);
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

        public IActionResult MasaGuncelle(int id)
        {
            var values = masaManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult MasaGuncelle(Masa masa)
        {
            ValidationResult validationResult = masaValidator.Validate(masa);
            if (validationResult.IsValid)
            {
                masaManager.Update(masa);
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

        public IActionResult AktifOlmayanMasalar()
        {
            var values = masaManager.GetInactiveMasaDto();
            return View(values);
        }
    }
}
