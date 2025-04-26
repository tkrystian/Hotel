using System.ComponentModel.DataAnnotations;

namespace Hotel.PortalWWW.Models.CMS
{
    public class Page
    {
        [Key]
        public int IdStrony { get; set; }

        [Required(ErrorMessage = "Tytuł odnośnika jest wymagany.")]
        [StringLength(20, ErrorMessage = "Tytuł odnośnika nie może przekraczać 20 znaków.")]
        [Display(Name = "Tytuł odnośnika")]
        public required string LinkTytul { get; set; }

        [Required(ErrorMessage = "Tytuł strony jest wymagany.")]
        [StringLength(100, ErrorMessage = "Tytuł strony nie może przekraczać 100 znaków.")]
        [Display(Name = "Tytuł strony")]
        public required string Tytul { get; set; }

        [Display(Name = "Treść")]
        [Required(ErrorMessage = "Treść jest wymagana.")]
        [StringLength(5000, ErrorMessage = "Treść nie może przekraczać 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        public required string Tresc { get; set; }

        [Display(Name = "Pozycja wyświetlania")]
        [Required(ErrorMessage = "Wprowadź pozycję wyświetlania.")]
        public int Pozycja { get; set; }

        public ICollection<Media>? MediaFiles { get; set; }
    }
}
