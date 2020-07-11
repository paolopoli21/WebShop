using System.Linq;
using Articoli_Web_Service.Models;
using Articoli_Web_Service.Security;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Articoli_Web_Service.Services
{
    public class UserService : IUserService
    {
        private AlphaShopDbContext alphaShopDbContext;

        public UserService(AlphaShopDbContext alphaShopDbContext){
            this.alphaShopDbContext = alphaShopDbContext;
        }
        public bool Authenticate(string username, string password)
        {
            bool retVal = false;

            PasswordHasher Hasher = new PasswordHasher();

            Utenti utente = this.GetUser(username);
            if (utente != null)
            {
                string EncryptPwd = utente.Password;
                
                retVal = Hasher.Check(EncryptPwd, password).Verified;
            }


            // Utenti utente = this.alphaShopDbContext.Utenti
            //     .Include(r => r.Profili)
            //     .Where(c => c.UserId  == username)
            //     .FirstOrDefault();

            // if (utente != null)
            // {
            //     string EncryptPwd = utente.Password;
                
            //     retVal = Hasher.Check(EncryptPwd, password).Verified;
            // }
            
            return retVal; 
        }

        public Utenti GetUser(string username)
        {
            return this.alphaShopDbContext.Utenti
                .Include(r => r.Profili)
                .Where(c => c.UserId == username)
                .FirstOrDefault();
        }
    }
}