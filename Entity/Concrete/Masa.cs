using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Masa : IEntity 
    {
        public int MasaId { get; set; }
        public int OfisId { get; set; }
        public string MasaAdi { get; set; }
        public string MasaKodu { get; set; }
        public bool Aktif { get; set; }
        public int KatilimciSayisi { get; set; }
    }
}
