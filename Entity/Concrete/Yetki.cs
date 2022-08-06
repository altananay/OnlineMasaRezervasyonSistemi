using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Yetki : IEntity
    {
        public int YetkiId { get; set; }
        public string YetkiTuru { get; set; }
    }
}
