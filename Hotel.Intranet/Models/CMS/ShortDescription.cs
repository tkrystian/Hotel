using System.ComponentModel.DataAnnotations;

namespace Hotel.PortalWWW.Models.CMS
{
    public class ShortDescription
    {
        [Key]
        public int IdOpisu { get; set; }

        [Required(ErrorMessage = "Nagłówek opisu jest wymagany.")]
        [StringLength(100, ErrorMessage = "Nagłówek opisu nie może przekraczać 100 znaków.")]
        [Display(Name = "Nagłówek opisu")]
        public required string Naglowek { get; set; }

        [Required(ErrorMessage = "Tagi są wymagane.")]
        [StringLength(100, ErrorMessage = "Tagi nie mogą przekraczać 100 znaków.")]
        [Display(Name = "Tagi")]
        public required string Tagi { get; set; }

        [Required(ErrorMessage = "Zdjęcie poglądowe jest wymagane.")]
        [StringLength(200, ErrorMessage = "Zdjęcie poglądowe nie może przekraczać 200 znaków.")]
        [Display(Name = "Zdjęcie poglądowe")]
        public required string Zdjecie { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        [StringLength(5000, ErrorMessage = "Treść nie może przekraczać 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść opisu")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Typ opisu jest wymagany.")]
        [StringLength(50, ErrorMessage = "Typ opisu nie może przekraczać 50 znaków.")]
        [Display(Name = "Typ opisu")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Pozycja jest wymagana.")]
        [Range(1, 100, ErrorMessage = "Pozycja musi być w zakresie od 1 do 100.")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        public ICollection<Media>? MediaFiles { get; set; }
    }
}
