using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class OfisController : Controller
    {
        OfisManager ofisManager = new OfisManager(new EfOfisDal());
        OfisValidator ofisValidator = new OfisValidator(); 
        public IActionResult Index()
        {
            var values = ofisManager.GetAll();
            return View(values);
        }

        public IActionResult OfisSil(int id)
        {
            var values = ofisManager.GetById(id);
            values.Aktif = false;
            ofisManager.Update(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult OfisEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult OfisEkle(Ofis ofis)
        {
            ValidationResult validationResult = ofisValidator.Validate(ofis);
            if (validationResult.IsValid)
            {
                ofisManager.Add(ofis);
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

        public IActionResult OfisGuncelle(int id)
        {
            var values = ofisManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult OfisGuncelle(Ofis ofis)
        {
            ValidationResult validationResult = ofisValidator.Validate(ofis);
            if (validationResult.IsValid)
            {
                ofisManager.Update(ofis);
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

        public IActionResult AktifOlmayanOfisler()
        {
            var values = ofisManager.ListInactive();
            return View(values);
        }
    }
}
