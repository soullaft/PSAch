using Microsoft.EntityFrameworkCore;
using PSAch.API.Models;

namespace PSAch.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get;set; }
    }
}
