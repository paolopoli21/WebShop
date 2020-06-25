using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("api/saluti")]
    public class SalutiController
    {
        public string getSaluti(){
            return "Saluti, cono il tuo primo webe service con #";
        }

        [HttpGet("{nome}")]
        public string getSaluti2(string nome) =>
             string.Format("\"Saluti, {0} il tuo primo servizio creato in c# core\"", nome);
        
    }

  
}