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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CustomPage>().HasData(new CustomPage
            {
                Id = -1,
                Title = "Home",
                Path = "Home",
                IsDeleted = false,
                IsGroup = false,
                ParentId = null,
            });

            modelBuilder.Entity<Configuration>().HasData(new Configuration
            {
                Id = 1,
                Key = Configuration.POST_VISIBLE,
                Value = "true"
            },
            new Configuration
            {
                Id = 2,
                Key = Configuration.FOOTER,
                Value = "<p>Plac Marii Skłodowskiej-Curie 5, 60-965 Poznań. Telefon: 61 665 35 37</p>"
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<JobOffer> JobOffer { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Form> Forms { get; set; }
        public DbSet<CustomPage> CustomPages { get; set; }
        public DbSet<PageElement> PageElements { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
    }
}