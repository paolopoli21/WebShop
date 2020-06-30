using System.Collections.Generic;
using System.Threading.Tasks;
using ArticoliWebService.Dtos;
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
        public async Task<IActionResult> GetArticoliByDesc(string filter){
            var articoliDto = new List<ArticoliDto>() ;
            var articoli = await this.articolirepository.SelArticoliByDescrizione(filter);
               if(!ModelState.IsValid){
                return BadRequest(ModelState);
            } 

            if(articoli.Count == 0){
                return NotFound(string.Format("Non è stato trovato alcun articolo con il filtro '{0}'", filter));
            }

            foreach(var articolo in articoli){
                articoliDto.Add(new ArticoliDto{
                    CodArt = articolo.CodArt,
                    Descrizione = articolo.Descrizione,
                    Um = articolo.Um,
                    CodStat = articolo.CodStat,
                    PzCart = articolo.PzCart,
                    PesoNetto = articolo.PesoNetto,
                    DataCreazione = articolo.DataCreazione
                    //IdStatoArt = articolo.IdStatoArt
                });
            }
            return Ok(articoliDto);
        }
    }
}