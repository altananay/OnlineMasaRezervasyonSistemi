using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Durum
{
    public class DurumList : ViewComponent
    {
        DurumManager durumManager = new DurumManager(new EfDurumDal());

        public IViewComponentResult Invoke()
        {
            var values = durumManager.GetAll();
            return View(values);
        }
    }
}
