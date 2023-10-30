using Microsoft.EntityFrameworkCore;
using DigitalBookstore.WebApi.Models;

namespace DigitalBookstore.WebApi.Models
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserBook> UsersBook { get; set; }
    }
}
