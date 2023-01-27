using Microsoft.EntityFrameworkCore;
using PSAch.API.Models;

namespace PSAch.API.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Game> Games { get;set; }

        public DbSet<Achievement> Achievements { get; set; }

        public DbSet<Photo> Photos { get; set; }

        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
