using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Sender's email")]
        public string Email { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        [Display(Name = "Handled")]
        public bool IsHandled { get; set; } = false;

    }
}
