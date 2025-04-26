using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ReservationHistory
{
    [Key]
    public int IdHistorii { get; set; }

    [Required]
    [ForeignKey("User")]
    public int IdUzytkownika { get; set; }
    public required User User { get; set; }

    [Required]
    [Display(Name = "Data rozpoczęcia")]
    public DateTime DataRozpoczecia { get; set; }

    [Required]
    [Display(Name = "Data zakończenia")]
    public DateTime DataZakonczenia { get; set; }

    [Required]
    [Display(Name = "Typ rezerwacji(Pokój/Atrakcja)")]
    [StringLength(50)]
    public required string TypRezerwacji { get; set; }

    [Required]
    [Display(Name = "Identyfikator obiektu")]
    public int ObiektId { get; set; }

    [Required]
    [Display(Name = "Status rezerwacji")]
    [StringLength(50)]
    public required string Status { get; set; } // np. "Zakończona", "Anulowana"

    [Display(Name = "Data utworzenia historii")]
    public DateTime DataUtworzenia { get; set; } = DateTime.Now;
}
