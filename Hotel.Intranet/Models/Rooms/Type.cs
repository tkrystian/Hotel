using System.ComponentModel.DataAnnotations;

namespace Hotel.PortalWWW.Models.Rooms
{
    public class Type
    {
        [Key]
        public int IdTypu { get; set; }

        [Required(ErrorMessage = "Nazwa typu pokoju jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa typu pokoju nie może przekraczać 100 znaków.")]
        [Display(Name = "Nazwa typu pokoju")]
        public required string Nazwa { get; set; }

        [Required(ErrorMessage = "Tagi są wymagane.")]
        [StringLength(100, ErrorMessage = "Tagi nie mogą przekraczać 100 znaków.")]
        [Display(Name = "Tagi")]
        public required string Tagi { get; set; }

        [Required(ErrorMessage = "Zdjęcie poglądowe jest wymagane.")]
        [StringLength(200, ErrorMessage = "Zdjęcie poglądowe nie może przekraczać 200 znaków.")]
        [Display(Name = "Zdjęcie poglądowe")]
        public required string Zdjecie { get; set; }

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(5000, ErrorMessage = "Opis nie może przekraczać 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść opisu")]
        public required string Opis { get; set; }

        public ICollection<Room>? Pokoje { get; } = new List<Room>();
    }
}
