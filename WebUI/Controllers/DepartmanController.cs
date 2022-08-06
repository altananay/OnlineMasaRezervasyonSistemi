using Business.Concrete;
using Business.ValidationRules;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DepartmanController : Controller
    {
        DepartmanManager departmanManager = new DepartmanManager(new EfDepartmanDal());
        DepartmanValidator departmanValidator = new DepartmanValidator();
        public IActionResult Index()
        {
            var values = departmanManager.GetAll();
            return View(values);
        }

        public IActionResult DepartmanSil(int id)
        {
            var values = departmanManager.GetById(id);
            values.Aktif = false;
            departmanManager.Update(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DepartmanEkle(Departman departman)
        {
            ValidationResult results = departmanValidator.Validate(departman);
            if (results.IsValid)
            {
                departmanManager.Add(departman);
                return RedirectToAction("Index");
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

        public IActionResult DepartmanGüncelle(int id)
        {
            var values = departmanManager.GetById(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult DepartmanGuncelle(Departman departman)
        {
            departmanManager.Update(departman);
            return RedirectToAction("Index");
        }

        public IActionResult AktifOlmayanDepartmanlar()
        {
            var values = departmanManager.GetInactive();
            return View(values);
        }
    }
}
