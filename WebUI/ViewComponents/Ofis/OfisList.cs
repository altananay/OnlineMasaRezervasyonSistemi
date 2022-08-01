using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Ofis
{
    public class OfisList : ViewComponent
    {
        OfisManager ofisManager = new OfisManager(new EfOfisDal());

        public IViewComponentResult Invoke()
        {
            var values = ofisManager.GetAll();
            return View(values);
        }
    }
}
