using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.PortalWWW.Models.Rooms
{
    public class Room
    {
        [Key]
        public int IdPokoju { get; set; }

        [Required(ErrorMessage = "Typ pokoju jest wymagany.")]
        [StringLength(100, ErrorMessage = "Typ pokoju nie może przekraczać 100 znaków.")]
        [Display(Name = "Typ pokoju")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Numer pokoju jest wymagany")]
        [Range(1, 1000, ErrorMessage = "Numer pokoju musi być w zakresie od 1 do 1000.")]
        [Display(Name = "Numer pokoju")]
        public int Numer { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(5000, ErrorMessage = "Opis nie może przekraczać 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść opisu")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Liczba osób jest wymagana.")]
        [Range(1, 10, ErrorMessage = "Liczba osób musi być w zakresie od 1 do 10.")]
        [Display(Name = "Liczba osób")]
        public int LiczbaOsob { get; set; }

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
