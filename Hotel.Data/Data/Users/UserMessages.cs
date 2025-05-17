using Hotel.Data.Data.Messages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data.Data.Users
{
    public class UserMessages
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Sender")]
        public int SenderId { get; set; }

        public User Sender { get; set; } = null!;

        [Required]
        [ForeignKey("Recipient")]
        public int RecipientId { get; set; }

        public User Recipient { get; set; } = null!;

        [Required]
        [ForeignKey("Message")]
        public int MessageId { get; set; }

        public Message Message { get; set; } = null!;

        public MessageStatus Status { get; set; }
    }
}
