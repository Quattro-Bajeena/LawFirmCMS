using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class JobOffer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Position { get; set; } = string.Empty;
        [Required]
        public int Salary { get; set; } = int.MaxValue;
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public string Requirements { get; set; } = string.Empty;
        [Required]
        [Display(Name = "Deleted")]
        public bool IsDeleted { get; set; } = false;
    }
}
