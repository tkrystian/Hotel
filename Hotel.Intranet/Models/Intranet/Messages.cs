using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Intranet.Models.Intranet
{
    public class Messages
    {
        [Key]
        public int IdWiadomosci { get; set; }

        [Required(ErrorMessage = "Temat wiadomości jest wymagany.")]
        [StringLength(100, ErrorMessage = "Temat wiadomości nie może przekraczać 100 znaków.")]
        [Display(Name = "Temat wiadomości")]
        public required string Temat { get; set; }

        [Required(ErrorMessage = "Treść wiadomości jest wymagana.")]
        [StringLength(5000, ErrorMessage = "Treść wiadomości nie może przekraczać 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Treść wiadomości")]
        public required string Tresc { get; set; }

        [Required(ErrorMessage = "Data wysłania wiadomości jest wymagana.")]
        [Display(Name = "Data wysłania wiadomości")]
        [DataType(DataType.Date)]
        public DateTime DataWyslania { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Nadawca wiadomości jest wymagany.")]
        [ForeignKey("SenderId")]
        [Display(Name = "Nadawca wiadomości")]
        public int NadawcaId { get; set; }

        [Required(ErrorMessage = "Odbiorca wiadomości jest wymagany.")]
        [ForeignKey("ReceiverId")]
        [Display(Name = "Odbiorca wiadomości")]
        public int OdbiorcaId { get; set; }

        public MessageStatus Status { get; set; }


    }

    public enum MessageStatus
    {
        Wyslana = 1,
        Odebrana = 2,
        Przeczytana = 3
    }
}
