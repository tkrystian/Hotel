using System.ComponentModel.DataAnnotations;

namespace Hotel.PortalWWW.Models.CMS
{
    public class Atraction
    {
        [Key]
        public int IdAtrakcji { get; set; }

        [Required(ErrorMessage = "Nazwa atrakcji jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa atrakcji nie może przekraczać 100 znaków.")]
        [Display(Name = "Nazwa atrakcji")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Zdjęcie atrakcji jest wymagane.")]
        [StringLength(200, ErrorMessage = "Zdjęcie atrakcji nie może przekraczać 200 znaków.")]
        [Display(Name = "Zdjęcie atrakcji")]
        public required string Zdjecie { get; set; }

        [Required(ErrorMessage = "Opis atrakcji jest wymagany.")]
        [StringLength(500, ErrorMessage = "Opis atrakcji nie może przekraczać 500 znaków.")]
        [Display(Name = "Opis atrakcji")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Typ atrakcji jest wymagany.")]
        [StringLength(50, ErrorMessage = "Typ atrakcji nie może przekraczać 50 znaków.")]
        [Display(Name = "Typ atrakcji")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Range(0, 10000, ErrorMessage = "Cena musi być w zakresie od 0 do 10000.")]
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Status atrakcji jest wymagany.")]
        [Display(Name = "Status atrakcji")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Pozycja jest wymagana.")]
        [Range(1, 100, ErrorMessage = "Pozycja musi być w zakresie od 1 do 100.")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        public ICollection<Media>? MediaFiles { get; set; }
    }
}
