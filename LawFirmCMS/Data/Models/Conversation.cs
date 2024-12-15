using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Conversation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public virtual ICollection<Message> Messages { get; } = new List<Message>();
    }
}
