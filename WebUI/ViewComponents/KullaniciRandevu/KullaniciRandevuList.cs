using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.KullaniciRandevu
{
    public class KullaniciRandevuList : ViewComponent
    {
        RandevuKayitManager randevuKayitManager = new RandevuKayitManager(new EfRandevuKayitDal());
        public IViewComponentResult Invoke(int id)
        {
            var values = randevuKayitManager.GetAllRandevuDtoById(id);
            return View(values);
        }
        
    }
}
