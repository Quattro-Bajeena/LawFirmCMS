using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Login {  get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public bool Boss { get; set; }

        [Required]
        public bool IsDeleted { get; set; } = false;


        public ICollection<Consultation> Consultations { get; } = new List<Consultation>();
        public ICollection<Post> Posts { get; } = new List<Post>();
        public ICollection<Schedule> Schedules { get; } = new List<Schedule>();
        public ICollection<Conversation> Conversations { get; } = new List<Conversation>();
        public ICollection<EmployeeSpecialization> EmployeeSpecializations { get; } = new List<EmployeeSpecialization>();
    }
}
