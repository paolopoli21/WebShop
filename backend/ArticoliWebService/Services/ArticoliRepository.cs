using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext alphaShopDbContext;

        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this.alphaShopDbContext = alphaShopDbContext;
        }
        public async Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione)
        {
              return await this.alphaShopDbContext.Articoli
                    .Where(a => a.Descrizione.Contains(Descrizione))
                    .Include(a => a.famAssort)
                    .OrderBy(a => a.Descrizione)
                    .ToListAsync();  
        }
        
        public async Task<Articoli> SelArticoloByCodice(string Code)
        {
            return await this.alphaShopDbContext.Articoli
                .Where(a => a.CodArt.Equals(Code))
                .Include(a => a.Barcode)
                .Include(a => a.famAssort)
                .FirstOrDefaultAsync();
        }

        public async Task<Articoli> SelArticoloByEan(string Ean)
        {
            return await this.alphaShopDbContext.Barcode
                .Where(b => b.Barcode.Equals(Ean))
                .Select(a => a.articolo)
                .FirstOrDefaultAsync();
        }

        
        public bool InsArticoli(Articoli articolo)
        {
            this.alphaShopDbContext.Add(articolo);
            return Salva();
        }

          public bool UpdArticoli(Articoli articolo)
        {
            this.alphaShopDbContext.Update(articolo);
            return Salva();
        }

        public bool DelArticoli(Articoli articolo)
        {
            this.alphaShopDbContext.Remove(articolo);
            return Salva();
        }

        public bool ArticoloExits(string Code)
        {
            return this.alphaShopDbContext.Articoli
                .Any(c => c.CodArt == Code);
        }

        public bool Salva()
        {
            var saved = this.alphaShopDbContext.SaveChanges();
            return saved > 0;
        }

        public Articoli SelArticoloByCodice2(string Code)
        {
            return this.alphaShopDbContext.Articoli
                .AsNoTracking()
                .Where(a => a.CodArt.Equals(Code))
                //.Include(a => a.Barcode)
                //.Include(a => a.famAssort)
                .FirstOrDefault();
        }
        
    }
}