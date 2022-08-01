using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfKullaniciDal : EfEntityRepositoryBase<Kullanici, OnlineMasaRezervasyonContext>, IKullaniciDal
    {
        public List<KullaniciDTO> GetKullaniciDto()
        {
            using (OnlineMasaRezervasyonContext context = new OnlineMasaRezervasyonContext())
            {
                var result = from k in context.Kullanicilar
                             join d in context.Departmanlar
                             on k.DepartmanId equals d.DepartmanId
                             select new KullaniciDTO { KullaniciId = k.KullaniciId, Ad = k.Ad, Soyad = k.Soyad, Eposta = k.Eposta, Gsm = k.Gsm, Gorev = k.Gorev, DepartmanAdı = d.DepartmanAdi };
                return result.ToList();
            }
        }
    }
}
