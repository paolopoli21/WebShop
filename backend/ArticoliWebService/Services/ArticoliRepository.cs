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
                    .OrderBy(a => a.Descrizione)
                    .ToListAsync();  
        }
        
        public async Task<Articoli> SelArticoloByCodice(string Code)
        {
            return await this.alphaShopDbContext.Articoli
                .Where(a => a.CodArt.Equals(Code))
                .FirstOrDefaultAsync();
        }

        public Articoli SelArticoloByEan(string Ean)
        {
            return this.alphaShopDbContext.Barcode
                .Where(b => b.Barcode.Equals(Ean))
                .Select(a => a.articolo)
                .FirstOrDefault();
        }

        
        public bool InsArticolo(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

          public bool UpdArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool DelArticoli(Articoli articolo)
        {
            throw new System.NotImplementedException();
        }

        public bool ArticoloExits(string Code)
        {
            return this.alphaShopDbContext.Articoli
                .Any(c => c.CodArt == Code);
        }

        public bool Salva()
        {
            throw new System.NotImplementedException();
        }


        

        



      
    }
}