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

        [Required(ErrorMessage = "Data rozpocz�cia jest wymagana.")]
        [Display(Name = "Data rozpocz�cia")]
        public DateTime DataRozpoczecia { get; set; }

        [Required(ErrorMessage = "Data zako�czenia jest wymagana.")]
        [Display(Name = "Data zako�czenia")]
        public DateTime DataZakonczenia { get; set; }

        [Required(ErrorMessage = "Typ rezerwacji jest wymagany.")]
        [Display(Name = "Typ rezerwacji")]
        [StringLength(50, ErrorMessage = "Typ rezerwacji nie mo�e przekracza� 50 znak�w.")]
        public required string TypRezerwacji { get; set; }

        [Display(Name = "Id u�ytkownika")]

        [ForeignKey("User")]
        public int UzytkownikId { get; set; }

        [NotMapped]
        public Atraction? Atraction { get; set; }

        [NotMapped]
        public Room? Room { get; set; }

    }
}
