using Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class OnlineMasaRezervasyonContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=MSI; Database=OnlineMasaRezervasyon; integrated security= true");
        }

        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Masa> Masalar { get; set; }
    }
}
