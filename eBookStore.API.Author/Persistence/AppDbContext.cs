using eBookStore.API.Author.Model;

using Microsoft.EntityFrameworkCore;

namespace eBookStore.API.Author.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
                
        public DbSet<AcademicDegree> AcademicDegrees { get; set; }
        public DbSet<Model.Author> Authors { get; set; }
    }
}
