using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class RandevuKayit : IEntity
    {
        public int RandevuId { get; set; }
        public int KullaniciId { get; set; }
        public int MasaId { get; set; }
        public DateTime BaslangicTarihi { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public DateTime BitisTarihi { get; set; }
        public TimeSpan BitisSaati { get; set; }
        public int DurumId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}