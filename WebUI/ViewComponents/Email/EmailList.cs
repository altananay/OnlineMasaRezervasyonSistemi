using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Email
{
    public class EmailList : ViewComponent
    {
        KullaniciManager kullaniciManager = new KullaniciManager(new EfKullaniciDal());
        public IViewComponentResult Invoke()
        {
            var values = kullaniciManager.GetAll();
            return View(values);
        }
    }
}
