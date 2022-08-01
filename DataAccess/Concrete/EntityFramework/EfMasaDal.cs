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
    public class EfMasaDal : EfEntityRepositoryBase<Masa, OnlineMasaRezervasyonContext>, IMasaDal
    {
        public List<MasaDTO> GetMasaDto()
        {
            using (OnlineMasaRezervasyonContext context = new OnlineMasaRezervasyonContext())
            {
                var result = from m in context.Masalar
                             join o in context.Ofisler
                             on m.OfisId equals o.OfisId
                             select new MasaDTO { MasaId = m.MasaId, OfisAdi = o.OfisAdi, MasaAdi = m.MasaAdi, MasaKodu = m.MasaKodu, Aktif = m.Aktif, KatilimciSayisi = m.KatilimciSayisi };
                return result.ToList();
            }
        }
    }
}
