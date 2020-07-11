using Articoli_Web_Service.Models;

namespace Articoli_Web_Service.Services
{
    public interface IUserService
    {
        bool Authenticate(string username, string password);
        Utenti GetUser(string username);

    }
}