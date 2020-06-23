using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Route("api/saluti")]
    public class SalutiController
    {
        public string getSaluti(){
            return "Saluti, cono il tuo primo webe service con #";
        }
        
    }
}