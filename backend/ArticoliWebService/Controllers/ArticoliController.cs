using System.Collections.Generic;
using ArticoliWebService.Models;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/articoli")]
    public class ArticoliController: Controller
    {
        private IArticoliRepository articolirepository;

        public ArticoliController(IArticoliRepository articolirepository){
            this.articolirepository = articolirepository;
        }

        [HttpGet("cerca/descrizione/{filter}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type =  typeof(IEnumerable<Articoli>))]
        public IActionResult GetArticoliByDesc(string filter){
            var articoli = this.articolirepository.SelArticoliByDescrizione(filter);
            return Ok(articoli);
        }
    }
}