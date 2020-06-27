using System.Collections.Generic;
using System.Linq;
using ArticoliWebService.Models;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext alphaShopDbContext;

        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this.alphaShopDbContext = alphaShopDbContext;
        }
        public ICollection<Articoli> SelArticoliByDescrizione(string Descrizione)
        {
              return this.alphaShopDbContext.Articoli
                    .Where(a => a.Descrizione.Contains(Descrizione))
                    .OrderBy(a => a.Descrizione)
                    .ToList();  
        }
        
        public Articoli SelArticoloByCodice(string Code)
        {
            return this.alphaShopDbContext.Articoli
                .Where(a => a.CodArt.Equals(Code))
                .FirstOrDefault();
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
            throw new System.NotImplementedException();
        }

        public bool Salva()
        {
            throw new System.NotImplementedException();
        }


        

        



      
    }
}