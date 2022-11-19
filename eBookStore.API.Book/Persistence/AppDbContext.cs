using Microsoft.EntityFrameworkCore;

namespace eBookStore.API.Book.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Model.Book> Books { get; set; }
    }
}
