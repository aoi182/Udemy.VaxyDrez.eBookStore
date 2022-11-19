using eBookStore.API.Basket.Model;

using Microsoft.EntityFrameworkCore;

using System;
using System.Threading.Tasks;

namespace eBookStore.API.Basket.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Model.Basket> Baskets { get; set; }
        public DbSet<Item> Items { get; set; }
    }
}
