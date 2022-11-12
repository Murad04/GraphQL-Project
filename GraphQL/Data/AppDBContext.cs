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
        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Command)
                .WithOne(p => p.Platform!)
                .HasForeignKey(p => p.PlatformID);

            modelBuilder.Entity<Command>()
                .HasOne(p => p.Platform)
                .WithMany(p => p.Command)
                .HasForeignKey(p => p.PlatformID);

            base.OnModelCreating(modelBuilder);
        }

    }
}
