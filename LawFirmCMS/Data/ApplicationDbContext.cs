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

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<Post> Posts { get; set; }
		public DbSet<Form> Forms { get; set; }
		public DbSet<CustomPage> CustomPages { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
    }
}