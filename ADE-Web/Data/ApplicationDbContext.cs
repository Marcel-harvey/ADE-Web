using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ADE_Web.Models;

namespace ADE_Web.Data
{
    public class ApplicationDbContext :IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Applications Models
        public DbSet<AppsBuilt> appsBuilt { get; set; }
        public DbSet<AppImprovement> appImprovement { get; set; }
    }
}
