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
        [HttpGet("cerca/codice/{CodArt}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type =  typeof(ArticoliDto))]
        public async Task<IActionResult> GetArticoloByCode(string CodArt){
            if(!this.articolirepository.ArticoloExits(CodArt)){
                return NotFound(string.Format("Articolo non codice '{0}'", CodArt));
            }

            var articolo = await this.articolirepository.SelArticoloByCodice(CodArt);
            var articoliDto = new ArticoliDto
            {
                CodArt = articolo.CodArt,
                Descrizione = articolo.Descrizione,
                Um = articolo.Um,
                CodStat = articolo.CodStat,
                PzCart = articolo.PzCart,
                PesoNetto = articolo.PesoNetto,
                DataCreazione = articolo.DataCreazione
                // Ean = barcodeDto,
                // Categoria = articolo.famAssort.Descrizione,
                // IdStatoArt = articolo.IdStatoArt
            };
            return Ok(articoliDto);
        }

        [HttpGet("cerca/barcode/{Ean}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticoliDto))]
        public async Task<IActionResult> GetArticoliByEan(string Ean){
            var articolo = await this.articolirepository.SelArticoloByEan(Ean);
            if(articolo == null){
                return NotFound(string.Format("Articolo non trovato '{0}'", Ean));
            }
            var articoliDto = new ArticoliDto
            {
                CodArt = articolo.CodArt,
                Descrizione = articolo.Descrizione,
                Um = articolo.Um,
                CodStat = articolo.CodStat,
                PzCart = articolo.PzCart,
                PesoNetto = articolo.PesoNetto,
                DataCreazione = articolo.DataCreazione
                // Categoria = articolo.famAssort.Descrizione,
                // IdStatoArt = articolo.IdStatoArt
            };
            return Ok(articoliDto);
        }
    }
}