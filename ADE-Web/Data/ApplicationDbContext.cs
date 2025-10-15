using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ADE_Web.Models;

namespace ADE_Web.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Convert time to CAT for PostgreSql
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var converter = new CatTimeConverter();

            // Apply to all DateTime properties in all entities
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var dateTimeProps = entityType.GetProperties()
                    .Where(p => p.ClrType == typeof(DateTime) || p.ClrType == typeof(DateTime?));

                foreach (var prop in dateTimeProps)
                    prop.SetValueConverter(converter);
            }
        }

        // Applications Models
        public DbSet<AppsBuiltModel> appsBuilt { get; set; }
        public DbSet<AppImprovementModel> appImprovement { get; set; }
        public DbSet<TechStackModel> techStack { get; set; }
        public DbSet<BlogModel> blog { get; set; }
    }
}
