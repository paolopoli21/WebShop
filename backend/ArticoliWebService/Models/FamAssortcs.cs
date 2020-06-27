using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class FamAssortcs
    {
        [Key]
        public int Id { get; set; }
        public string Descrizione { get; set; }
    }
}