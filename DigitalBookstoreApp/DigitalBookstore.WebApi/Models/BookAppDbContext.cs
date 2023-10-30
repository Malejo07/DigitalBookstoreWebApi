using Microsoft.EntityFrameworkCore;
using DigitalBookstore.WebApi.Models;

namespace DigitalBookstore.WebApi.Models
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserBook> UsersBooks { get; set; }
    }
}
