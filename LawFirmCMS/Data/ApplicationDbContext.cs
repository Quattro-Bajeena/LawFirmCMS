using LawFirmCMS.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Consultation> Consultations { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeSpecialization> EmployeeSpecializations { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Specialization> Specializations { get; set; }    
    }
}