using Hotel.PortalWWW.Models.Atractions;
using Hotel.PortalWWW.Models.Rooms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Availability
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int ObiektId { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public bool IsAvailable { get; set; }

    [NotMapped]
    public Atraction? Atraction { get; set; }

    [NotMapped]
    public Room? Room { get; set; }
}
