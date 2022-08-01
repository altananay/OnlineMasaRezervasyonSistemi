using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class KullaniciAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
