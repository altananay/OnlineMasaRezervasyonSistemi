using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class TakvimController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
