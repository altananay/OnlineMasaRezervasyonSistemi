using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class RandevuDTO : IDto
    {
        public int RandevuId { get; set; }
        public string KullaniciAd { get; set; }
        public string KullaniciSoyad { get; set; }
        public string OfisAdi { get; set; }
        public string MasaAdi { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public DateTime BitisTarihi { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public string Durum { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
