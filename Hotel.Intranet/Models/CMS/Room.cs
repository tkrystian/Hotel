using System.ComponentModel.DataAnnotations;

namespace Hotel.PortalWWW.Models.CMS
{
    public class Room
    {
        [Key]
        public int IdPokoju { get; set; }

        [Required(ErrorMessage = "Nazwa pokoju jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa pokoju nie może przekraczać 100 znaków.")]
        [Display(Name = "Nazwa pokoju")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Zdjęcie pokoju jest wymagane.")]
        [StringLength(200, ErrorMessage = "Zdjęcie pokoju nie może przekraczać 200 znaków.")]
        [Display(Name = "Zdjęcie pokoju")]
        public required string Zdjecie { get; set; }

        [Required(ErrorMessage = "Opis pokoju jest wymagany.")]
        [StringLength(500, ErrorMessage = "Opis pokoju nie może przekraczać 500 znaków.")]
        [Display(Name = "Opis pokoju")]
        public required string Opis { get; set; }

        [Required(ErrorMessage = "Typ pokoju jest wymagany.")]
        [StringLength(50, ErrorMessage = "Typ pokoju nie może przekraczać 50 znaków.")]
        [Display(Name = "Typ pokoju")]
        public required string Typ { get; set; }

        [Required(ErrorMessage = "Liczba osób jest wymagana.")]
        [Range(1, 10, ErrorMessage = "Liczba osób musi być w zakresie od 1 do 10.")]
        [Display(Name = "Liczba osób")]
        public int LiczbaOsob { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana.")]
        [Range(0, 10000, ErrorMessage = "Cena musi być w zakresie od 0 do 10000.")]
        [Display(Name = "Cena")]
        [DataType(DataType.Currency)]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Status pokoju jest wymagany.")]
        [Display(Name = "Status pokoju")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "Pozycja jest wymagana.")]
        [Range(1, 100, ErrorMessage = "Pozycja musi być w zakresie od 1 do 100.")]
        [Display(Name = "Pozycja wyświetlania")]
        public int Pozycja { get; set; }

        public ICollection<Media>? MediaFiles { get; set; }

    }
}
