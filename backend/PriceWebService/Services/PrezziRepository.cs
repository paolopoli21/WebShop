using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Models;
using System.Data.SqlClient;
using System.Linq;

namespace Services
{
    public class PrezziRepository: IPrezziRepository
    {
        private AlphaShopDbContext alphaShopDbContext;

        public PrezziRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this.alphaShopDbContext = alphaShopDbContext;
        }

        public async Task<DettListini> SelPrezzoByCodArtAndList(string CodArt, string IdListino)
        {
            return await alphaShopDbContext.DettListini
                .Where(a => a.CodArt.Equals(CodArt) && a.IdList.Equals(IdListino))
                .FirstOrDefaultAsync();
        }

        public bool PrezzoExists(string CodArt, string IdListino)
        {
            return this.alphaShopDbContext.DettListini
                .Any(a => a.CodArt.Equals(CodArt) && a.IdList.Equals(IdListino));
        }

        public bool DelPrezzoListino(string CodArt, string IdListino)
        {
            
            var Sql = "DELETE FROM DETTLISTINI WHERE CodArt = '"+ CodArt +"' AND IdList = '"+ IdListino +"'";
            // var parCode = new SqlParameter("@CodArt ", CodArt);
            // var parList = new SqlParameter("@IdList", IdListino);

            // int righe = this.alphaShopDbContext
            //     .Database.ExecuteSqlCommand(Sql, parCode, parList);
            var listino = this.alphaShopDbContext.DettListini.SingleOrDefault(x => x.CodArt.Equals(CodArt) && x.IdList.Equals(IdListino));
            this.alphaShopDbContext.DettListini.Remove(listino);
            int righe =this.alphaShopDbContext.SaveChanges();
            return (righe > 0) ? true : false; 
        }
    }
}