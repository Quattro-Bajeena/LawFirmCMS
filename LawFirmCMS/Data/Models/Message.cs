using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Index { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public int ConversationId { get; set; }
        public Conversation Conversation { get; set; }
    }
}
