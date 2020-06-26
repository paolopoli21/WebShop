using System;
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
        public string getSaluti2(string nome)
        {

             try{
                if(nome =="Marco")
                    throw new Exception("\"Errore: L'utente Marco non è abilitato!\"");
                else
                    return string.Format("\"Saluti, {0} il tuo primo servizio creato in c# core\"", nome);

            }
            catch(Exception ex){
                return ex.Message;
            }
        }
            // string.Format("\"Saluti, {0} il tuo primo servizio creato in c# core\"", nome);
        
    }

  
}