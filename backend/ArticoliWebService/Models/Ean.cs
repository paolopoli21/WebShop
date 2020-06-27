using System.ComponentModel.DataAnnotations;

namespace ArticoliWebService.Models
{
    public class Ean
    {
        public string CodArt { get; set; }
        [Key]
        [StringLength(13, MinimumLength=8, ErrorMessage="Il barcode deve avere fr 8 e 13 caratteri")]
        
        public string Barcode { get; set; }
        [Required]
        public string IdTipoArt { get; set; }

    }
}