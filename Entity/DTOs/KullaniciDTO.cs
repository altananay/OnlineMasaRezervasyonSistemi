using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTOs
{
    public class KullaniciDTO : IDto
    {
        public int KullaniciId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Eposta { get; set; }
        public string? Gsm { get; set; }
        public string? Gorev { get; set; }
        public string? DepartmanAdı { get; set; }
    }
}
