using Hotel.Intranet.Models.Intranet;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key]
    public int IdUzytkownika { get; set; }

    [Required(ErrorMessage = "Rola użytkownika jest wymagana.")]
    [StringLength(20, ErrorMessage = "Rola użytkownika nie może przekraczać 20 znaków.")]
    [Display(Name = "Rola użytkownika")]
    public required string Rola { get; set; }

    [Required(ErrorMessage = "Imię jest wymagane.")]
    [StringLength(50, ErrorMessage = "Imię nie może przekraczać 50 znaków.")]
    [Display(Name = "Imię")]
    public required string Imie { get; set; }

    [Required(ErrorMessage = "Nazwisko jest wymagane.")]
    [StringLength(50, ErrorMessage = "Nazwisko nie może przekraczać 50 znaków.")]
    [Display(Name = "Nazwisko")]
    public required string Nazwisko { get; set; }

    [Required(ErrorMessage = "Adres e-mail jest wymagany.")]
    [EmailAddress(ErrorMessage = "Nieprawidłowy format adresu e-mail.")]
    [Display(Name = "Adres e-mail")]
    public required string Email { get; set; }

    [Phone(ErrorMessage = "Nieprawidłowy format numeru telefonu.")]
    [Display(Name = "Numer telefonu (opcjonalnie)")]
    public string? Telefon { get; set; }

    [Required(ErrorMessage = "Hasło jest wymagane.")]
    [StringLength(100, ErrorMessage = "Hasło musi mieć co najmniej 6 znaków.", MinimumLength = 6)]
    [DataType(DataType.Password)]
    [Display(Name = "Hasło")]
    public required string Haslo { get; set; }

    public ICollection<Reservation>? Rezerwacje { get; set; } = new List<Reservation>();
    public ICollection<Messages>? WiadomosciWyslane { get; set; } = new List<Messages>();
    public ICollection<Messages>? WiadomosciOdebrane { get; set; } = new List<Messages>();

}
