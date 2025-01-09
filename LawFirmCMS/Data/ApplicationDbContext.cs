using LawFirmCMS.Data.Models;
using LawFirmCMS.Services;
using Microsoft.EntityFrameworkCore;

namespace LawFirmCMS.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = -1,
                Name = "Admin",
                Surname = "Admin",
                Login = "admin",
                PasswordHash = AccountService.HashPasword("password"),
                Boss = true
            },
            new Employee
            {
                Id = -2,
                Name = "Employee",
                Surname = "Employee",
                Login = "employee",
                PasswordHash = AccountService.HashPasword("1234"),
                Boss = false
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<CustomPage> CustomPages { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
    }
}