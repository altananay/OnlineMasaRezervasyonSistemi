using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class MasaKatilimcisi : IEntity
    {
        public int KullaniciId { get; set; }
        public int RandevuId { get; set; }
    }
}
