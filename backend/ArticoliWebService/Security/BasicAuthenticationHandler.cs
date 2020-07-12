using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Articoli_Web_Service.Models;
using Articoli_Web_Service.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Articoli_Web_Service.Security
{
    public class BasicAuthenticationHandler: AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IUserService userService;
        //private readonly BasicAuthenticationService _authenticationService;
        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IUserService userService
        ): base(options, logger, encoder, clock)
        {
            this.userService = userService;
        }

        // protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        // {
        //     throw new NotImplementedException();
        // }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if(!Request.Headers.ContainsKey("Authorization")){
                return  AuthenticateResult.Fail("Authorization header mancante");
                //return AuthenticateResult.NoResult();
            }
            Utenti utente = null;
            bool IsOk = false;

            try{
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');

                var username = credentials[0];
                var password = credentials[1];

                IsOk = await userService.Authenticate(username, password);

                if(IsOk){
                    utente = await userService.GetUser(username);
                }
            }
            catch{
                return AuthenticateResult.Fail("Authorization header mancante");
            }

            if(!IsOk){
                return AuthenticateResult.Fail("Authorization header mancante");
            }

            ICollection<Profili> userProliles = utente.Profili;

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, utente.UserId));

            foreach(var profile in userProliles){
                claims.Add(new Claim(ClaimTypes.Role, profile.Tipo));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);
            //throw new NotImplementedException();
            return AuthenticateResult.Success(ticket);

        }

        
    }
}