using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class MasaDTO : IDto
    {
        public int MasaId { get; set; }
        public string OfisAdi { get; set; }
        public string MasaAdi { get; set; }
        public string MasaKodu { get; set; }
        public bool Aktif { get; set; }
        public int KatilimciSayisi { get; set; }
    }
}
