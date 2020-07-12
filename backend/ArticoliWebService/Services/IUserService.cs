using System.Threading.Tasks;
using Articoli_Web_Service.Models;

namespace Articoli_Web_Service.Services
{
    public interface IUserService
    {
        Task<bool> Authenticate(string username, string password);
        Task<Utenti> GetUser(string username);

    }
}