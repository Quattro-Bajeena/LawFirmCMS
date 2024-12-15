using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Consultation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime dateTime { get; set; }
        [Required]
        public bool Confirmation { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public Employee Employee { get; set; }
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        public int SpecializationId { get; set; }
        public Specialization Specialization { get; set; }
    }
}

