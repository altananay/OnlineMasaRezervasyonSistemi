using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Durum : IEntity
    {
        public int DurumId { get; set; }
        public string Durumm { get; set; }
    }
}