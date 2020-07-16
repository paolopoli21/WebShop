using System.Threading.Tasks;
using Models;

namespace Services
{
    public interface IPrezziRepository
    {
        bool PrezzoExists(string CodArt, string IdListino);
        Task<DettListini> SelPrezzoByCodArtAndList(string CodArt , string IdListino);
        bool DelPrezzoListino(string CodArt , string IdListino);
    }
}