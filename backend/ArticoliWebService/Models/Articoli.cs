using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Articoli
    {
        [Key]
        [MinLength(5, ErrorMessage = "Il numero minimo di caratteri è 5")]
        [MaxLength(30, ErrorMessage="Il numero massimo di caratteri è 30")]
        public string CodArt { get; set; }
        [MinLength (5, ErrorMessage= "La Descrizione deve avere almeno 5 caratteri")]
        [MaxLength(80, ErrorMessage="La Descrione deve avere come massimo 80 caratteri")]
        public string Descrizione { get; set; }
        public string Um { get; set; }
        public string CodStat { get; set; }
        [Range(0, 100 , ErrorMessage="i pezzi per cartone devono essere compresi fra 0 e 100")]
        public Int16? PzCart { get; set; }

        public double? PesoNetto { get; set; }
        public int? IdIva {get; set;}
        public int? IdFamAss { get; set; }
        public string IdStatoArt { get; set; }
        public DateTime? DataCreazione { get; set; }

        public virtual ICollection<Ean> Barcode { get; set; }
        public virtual Ingredienti ingredienti  { get; set; }

        public virtual Iva iva { get; set; }
        public FamAssort famAssort { get; set; }

    }
}