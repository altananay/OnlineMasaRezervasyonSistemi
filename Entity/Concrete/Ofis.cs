using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Ofis : IEntity
    {
        public int OfisId { get; set; }
        public string OfisAdi { get; set; }
        public bool Aktif { get; set; }
    }
}
