using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class ingredientics
    {
        [Key]
        public string CodArt { get; set; }
        public string Info { get; set; }
    }
}