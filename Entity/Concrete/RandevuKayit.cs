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
        public DateTime BitisSaati { get; set; }
        public int DurumId { get; set; }
        public string Aciklama { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}