using Microsoft.EntityFrameworkCore;
using Million.Luxury.Domain.Entities;
using System.Collections.Generic;

namespace Million.Luxury.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet para tus entidades
        public DbSet<Property> Properties { get; set; }
    }
}
