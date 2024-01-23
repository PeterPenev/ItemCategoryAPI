using ItemsAPI.Data.Model;
using Microsoft.EntityFrameworkCore;
using static ItemsAPI.Data.Configurations;

namespace ItemsAPI.Data
{
    public class DenshiContext : DbContext
    {
        public DenshiContext() { }

        public DenshiContext(DbContextOptions options) : base(options) { }

        public DbSet<Item> Items { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
    }
}
