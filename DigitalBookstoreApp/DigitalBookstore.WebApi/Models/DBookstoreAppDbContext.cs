using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace DigitalBookstore.WebApi.Models
{
    public class DBookstoreAppDbContext : DbContext
    {
        public DBookstoreAppDbContext(DbContextOptions<DBookstoreAppDbContext>options) : base(options) { }

        public DbSet<User>Users { get; set; }
        public DbSet<Book>Books { get; set; }

    }
}
