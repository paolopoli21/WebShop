using System.Collections.Generic;
using System.Threading.Tasks;
using ArticoliWebService.Models;

namespace ArticoliWebService.Services
{
    public interface IArticoliRepository
    {
        Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione);

        Task<Articoli> SelArticoloByCodice(string Code);

        Task<Articoli> SelArticoloByEan(string Ean);

        bool InsArticolo(Articoli articolo);

        bool UpdArticoli(Articoli articolo);

        bool DelArticoli(Articoli articolo);
        bool Salva();

        bool ArticoloExits(string Code);
        
    }
}