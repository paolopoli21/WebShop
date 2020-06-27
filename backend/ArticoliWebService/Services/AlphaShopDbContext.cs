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
            
        }
        
    }
}