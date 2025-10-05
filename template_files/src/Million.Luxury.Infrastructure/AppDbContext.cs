using Microsoft.EntityFrameworkCore;
using Million.Luxury.Infrastructure.Entities;

namespace Million.Luxury.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<PropertyEntity> Properties { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyEntity>(eb =>
            {
                eb.HasKey(p => p.Id);
                eb.Property(p => p.Title).HasMaxLength(200).IsRequired();
            });
        }
    }
}
