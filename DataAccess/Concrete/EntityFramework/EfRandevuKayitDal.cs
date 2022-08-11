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
    public class EfRandevuKayitDal : EfEntityRepositoryBase<RandevuKayit, OnlineMasaRezervasyonContext>, IRandevuKayitDal
    {
        public RandevuDTO GetRandevuDto()
        {
            using (OnlineMasaRezervasyonContext context = new OnlineMasaRezervasyonContext())
            {
                var result = from rk in context.RandevuKayitlari
                             join k in context.Kullanicilar
                             on rk.KullaniciId equals k.KullaniciId
                             join m in context.Masalar
                             on rk.MasaId equals m.MasaId
                             join o in context.Ofisler
                             on m.OfisId equals o.OfisId
                             join d in context.Durumlar
                             on rk.DurumId equals d.DurumId
                             select new RandevuDTO { RandevuId = rk.RandevuId, KullaniciAd = k.Ad, KullaniciSoyad = k.Soyad, OfisAdi = o.OfisAdi, MasaAdi = m.MasaAdi, BaslangicTarihi = rk.BaslangicTarihi, BaslangicSaati = rk.BaslangicSaati, BitisTarihi = rk.BitisTarihi, BitisSaati = rk.BitisSaati, Durum = d.Durumm, Aciklama = rk.Aciklama, KayitTarihi = rk.KayitTarihi };
                return result.FirstOrDefault();
            }
        }

        public List<RandevuDTO> GetAllRandevuDtoById(int id)
        {
            using (OnlineMasaRezervasyonContext context = new OnlineMasaRezervasyonContext())
            {
                var result = from rk in context.RandevuKayitlari
                             join k in context.Kullanicilar
                             on rk.KullaniciId equals k.KullaniciId
                             join m in context.Masalar
                             on rk.MasaId equals m.MasaId
                             join o in context.Ofisler
                             on m.OfisId equals o.OfisId
                             join d in context.Durumlar
                             on rk.DurumId equals d.DurumId
                             where rk.KullaniciId == id
                             select new RandevuDTO { RandevuId = rk.RandevuId, KullaniciAd = k.Ad, KullaniciSoyad = k.Soyad, OfisAdi = o.OfisAdi, MasaAdi = m.MasaAdi, BaslangicTarihi = rk.BaslangicTarihi, BaslangicSaati = rk.BaslangicSaati, BitisTarihi = rk.BitisTarihi, BitisSaati = rk.BitisSaati, Durum = d.Durumm, Aciklama = rk.Aciklama, KayitTarihi = rk.KayitTarihi };
                return result.ToList();
            }
        }
    }
}
