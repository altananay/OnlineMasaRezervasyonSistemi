using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Departman : IEntity
    {
        public int DepartmanId { get; set; }
        public string? DepartmanAdi { get; set; }
    }
}
