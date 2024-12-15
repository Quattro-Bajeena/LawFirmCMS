using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        public Employee Employee { get; set; }
        public int EmployeeId { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;

    }
}
