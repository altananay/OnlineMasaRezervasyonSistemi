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
        public DbSet<Ofis> Ofisler { get; set; }
        public DbSet<Durum> Durumlar { get; set; }
        public DbSet<RandevuKayit> RandevuKayitlari { get; set; }
        public DbSet<Yetki> Yetkiler { get; set; }
        public DbSet<RandevuKatilimcisi> RandevuKatilimcilari { get; set; }

        //Custom mapping
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Durum>().ToTable("Durumlar");

            modelBuilder.Entity<Durum>().Property(d => d.Durumm).HasColumnName("Durum");

            modelBuilder.Entity<RandevuKayit>(rk =>
            {
                rk.Property<int>("RandevuId");
                rk.HasKey("RandevuId");
            });

            modelBuilder.Entity<Yetki>().Property(y => y.YetkiTuru).HasColumnName("Yetki");

            modelBuilder.Entity<RandevuKatilimcisi>(rka =>
            {
                rka.Property<int>("RandevuKatilimciId");
                rka.HasKey("RandevuKatilimciId");
            });
        }
    }
}
