using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DepartmanController : Controller
    {
        DepartmanManager departmanManager = new DepartmanManager(new EfDepartmanDal());

        public IActionResult Index()
        {
            var values = departmanManager.GetAll();
            return View(values);
        }

        public IActionResult DepartmanSil(int departmanId)
        {
            var values = departmanManager.GetById(departmanId);
            departmanManager.Delete(values);
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
            departmanManager.Add(departman);
            return RedirectToAction("Index");
        }
    }
}
