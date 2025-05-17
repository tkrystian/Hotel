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

        [Required(ErrorMessage = "Nag³ówek jest wymagany.")]
        [StringLength(100, ErrorMessage = "Nag³ówek nie mo¿e przekraczaæ 100 znaków.")]
        [Display(Name = "Nag³ówek strony")]
        public string Naglowek { get; set; } = string.Empty;

        [Required(ErrorMessage = "Tagi s¹ wymagane.")]
        [StringLength(200, ErrorMessage = "Tagi nie mog¹ przekraczaæ 200 znaków.")]
        [Display(Name = "Tagi strony")]
        public string Tagi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Opis jest wymagany.")]
        [StringLength(5000, ErrorMessage = "Opis nie mo¿e przekraczaæ 5000 znaków.")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Opis strony")]
        public string Opis { get; set; } = string.Empty;

        [Display(Name = "Pokoje")]
        public ICollection<Room>? Pokoje { get; set; } = new List<Room>();

        [Display(Name = "Atrakcje")]
        public ICollection<Atraction>? Atrakcje { get; set; } = new List<Atraction>();
    }
}