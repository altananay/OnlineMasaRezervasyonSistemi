using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Departman
{
    public class DepartmanList : ViewComponent
    {
        DepartmanManager departmanManager = new DepartmanManager(new EfDepartmanDal());

        public IViewComponentResult Invoke()
        {
            var values = departmanManager.GetAll();
            return View(values);
        }
    }
}
