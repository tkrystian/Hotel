using Hotel.PortalWWW.Models.Atractions;
using Hotel.PortalWWW.Models.Rooms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Media
{
    [Key]
    public int IdMedia { get; set; }

    [Required(ErrorMessage = "Nazwa pliku jest wymagana.")]
    [StringLength(200, ErrorMessage = "Nazwa pliku nie może przekraczać 200 znaków.")]
    [Display(Name = "Nazwa pliku")]
    public required string FileName { get; set; }

    [Required(ErrorMessage = "Ścieżka pliku jest wymagana.")]
    [StringLength(500, ErrorMessage = "Ścieżka pliku nie może przekraczać 500 znaków.")]
    [Display(Name = "Pełna nazwa pliku")]
    public required string FilePath { get; set; }

    [Required(ErrorMessage = "Typ pliku jest wymagany.")]
    [StringLength(50, ErrorMessage = "Typ pliku nie może przekraczać 50 znaków.")]
    [Display(Name = "Typ pliku")]
    public required string FileType { get; set; }

    [Display(Name = "Typ powiązanego obiektu")]
    [StringLength(50)]
    public string? RelatedObjectType { get; set; }

    [Display(Name = "Data dodania")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public ICollection<Room>? Rooms { get; set; } = new List<Room>();
    public ICollection<Atraction>? Atractions { get; set; } = new List<Atraction>();
}
