using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.PortalWWW.Models.Atractions
{
    public class Atraction
    {
        [Key]
        public int IdAtrakcji { get; set; }

        [Required(ErrorMessage = "Nazwa atrakcji jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa atrakcji nie może przekraczać 100 znaków.")]
        [Display(Name = "Nazwa atrakcji")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(5000, ErrorMessage = "Opis nie może przekraczać 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść opisu")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Range(0, 10000, ErrorMessage = "Cena musi być w zakresie od 0 do 10000.")]
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Status jest wymagany.")]
        [StringLength(50, ErrorMessage = "Status nie może przekraczać 50 znaków.")]
        [Display(Name = "Status")]
        public required string Status { get; set; }

        [Display(Name = "Media")]
        public int? MediaId { get; set; }

        [ForeignKey("MediaId")]
        public Media? Media { get; set; }


        [Display(Name = "Strona główna")]
        public int? HomePageId { get; set; }
        [ForeignKey("HomePageId")]
        public HomePage? HomePage { get; set; }

    }
}
