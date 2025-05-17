using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hotel.Data.Data.DTO
{
    public class MessageDto
    {
        public int IdWiadomosci { get; set; }
        public string? Temat { get; set; }
        public string? Tresc { get; set; }
        public DateTime DataWyslania { get; set; }

        public int SenderId { get; set; }
        public int RecipientId { get; set; }
        public string? SenderName { get; set; }
        public string? RecipientName { get; set; }

        public List<SelectListItem> Users { get; set; } = new List<SelectListItem>();
    }

}
