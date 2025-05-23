using Hotel.Data.Data.Atractions;
using Hotel.Data.Data.Rooms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Data.Reservations
{
    public class Reservation
    {
        [Key]
        public int IdRezerwacji { get; set; }

        [Required(ErrorMessage = "Data rozpoczęcia jest wymagana.")]
        [Display(Name = "Data rozpoczęcia")]
        public DateTime DataRozpoczecia { get; set; }

        [Required(ErrorMessage = "Data zakończenia jest wymagana.")]
        [Display(Name = "Data zakończenia")]
        public DateTime DataZakonczenia { get; set; }

        [Required(ErrorMessage = "Typ rezerwacji jest wymagany.")]
        [Display(Name = "Typ rezerwacji")]
        [StringLength(50, ErrorMessage = "Typ rezerwacji nie może przekraczać 50 znaków.")]
        public required string TypRezerwacji { get; set; }

        [Display(Name = "Id użytkownika")]

        [ForeignKey("User")]
        public int UzytkownikId { get; set; }

        [NotMapped]
        public Atraction? Atraction { get; set; }

        [NotMapped]
        public Room? Room { get; set; }

    }
}
