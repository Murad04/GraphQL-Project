using GraphQL.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Platform> Platforms { get; set; }
    }
}
