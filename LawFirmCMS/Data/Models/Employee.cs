using System.ComponentModel.DataAnnotations;

namespace LawFirmCMS.Data.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public bool Boss { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;


        public virtual ICollection<Consultation> Consultations { get; } = new List<Consultation>();
        public virtual ICollection<Post> Posts { get; } = new List<Post>();
        public virtual ICollection<Schedule> Schedules { get; } = new List<Schedule>();
        public virtual ICollection<Conversation> Conversations { get; } = new List<Conversation>();
        public virtual ICollection<EmployeeSpecialization> EmployeeSpecializations { get; } = new List<EmployeeSpecialization>();
    }
}
