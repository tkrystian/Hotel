using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Hotel.Data.Data.Atractions;
using Hotel.Data.Data.Rooms;

namespace Hotel.Data.Data.CMS
{
    public class HomePage
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Baner")]
        public int? BannerId { get; set; }
        [ForeignKey("BannerId")]
        public Media? Banner { get; set; }

        [Display(Name = "Grafika")]
        public int? GrafikaId { get; set; }
        [ForeignKey("GrafikaId")]
        public Media? Grafika { get; set; }

        [Required(ErrorMessage = "Nag��wek jest wymagany.")]
        [StringLength(100, ErrorMessage = "Nag��wek nie mo�e przekracza� 100 znak�w.")]
        [Display(Name = "Nag��wek strony")]
        public string Naglowek { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tagi s� wymagane.")]
        [StringLength(200, ErrorMessage = "Tagi nie mog� przekracza� 200 znak�w.")]
        [Display(Name = "Tagi strony")]
        public string Tagi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(5000, ErrorMessage = "Opis nie mo�e przekracza� 5000 znak�w.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Opis strony")]
        public string Opis { get; set; } = string.Empty;

        [Display(Name = "Pokoje")]
        public ICollection<Room>? Pokoje { get; set; } = new List<Room>();

        [Display(Name = "Atrakcje")]
        public ICollection<Atraction>? Atrakcje { get; set; } = new List<Atraction>();
    }
}