using Microsoft.EntityFrameworkCore;

namespace Manantial.Api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Define your DbSets here. For example:
        // public DbSet<EntityName> EntityNames { get; set; }
    }
}