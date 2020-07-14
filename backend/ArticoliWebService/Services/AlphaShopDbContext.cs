using Articoli_Web_Service.Models;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class AlphaShopDbContext : DbContext
    {
        public AlphaShopDbContext(DbContextOptions<AlphaShopDbContext> options)
        :base(options)
        {

        }

        public virtual DbSet<Articoli> Articoli { get; set;}
        public virtual DbSet<Ean> Barcode { get; set; }
        public virtual DbSet<FamAssort> Famassort { get; set; }
        public virtual  DbSet<Ingredienti> Ingredienti { get; set; }
        public virtual DbSet<Iva> Iva { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articoli>()
                .HasKey(a => new {a.CodArt});

            //Relazione one to many

            modelBuilder.Entity<Ean>()
            .HasOne<Articoli>(s => s.articolo) // ad un articolo
            .WithMany(g=> g.Barcode)     //corrispondono molti barcod
            .HasForeignKey(s => s.CodArt); // foreng key della tabella barcode

            //realzion fra articoli ingredienti relazione 1 a 1

            modelBuilder.Entity<Articoli>()
            .HasOne<Ingredienti>(s => s.ingredienti) //ad un articolo
            .WithOne(g => g.articolo) // corripnde un ingrediente
            .HasForeignKey<Ingredienti>(s => s.CodArt);

            //Relazione 1 a molti fra iva e articoli

            modelBuilder.Entity<Articoli>()
            .HasOne<Iva>(s => s.iva)
            .WithMany(g => g.articoli)
            .HasForeignKey(s => s.IdIva);

            //Relazione one to many fra Famassort e articoli
            modelBuilder.Entity<Articoli>()
            .HasOne<FamAssort>(s => s.famAssort)
            .WithMany(g => g.Articoli)
            .HasForeignKey(s => s.IdFamAss);
            
        }
        
    }
}