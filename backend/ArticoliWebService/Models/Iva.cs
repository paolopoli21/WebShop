using System;
using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Iva
    {
        [Key]
        public int IdIva { get; set; }
        public string Descrizone {get; set;}
        [Required]
        public Int16 Aliquota { get; set; }
    }
}