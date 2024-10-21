using EntegrasyonSistemi.Entity;
using Microsoft.EntityFrameworkCore;

namespace EntegrasyonSistemi.Models
{
    public class IntegrationDatabaseContext:DbContext
    {
        public IntegrationDatabaseContext(DbContextOptions<IntegrationDatabaseContext> options):base(options)
        {

        }

        public DbSet<User> users { get; set; }
    }
}
