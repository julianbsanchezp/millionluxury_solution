using Million.Luxury.Application.Ports;
using Million.Luxury.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Million.Luxury.Infrastructure.Entities;
using System.Linq;

namespace Million.Luxury.Infrastructure.Repositories
{
    public class SqlPropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _db;
        public SqlPropertyRepository(AppDbContext db) { _db = db; }
        public async Task AddAsync(Property property)
        {
            var entity = new PropertyEntity
            {
                Id = property.Id,
                Title = property.Title,
                Description = property.Description,
                Price = property.Price,
                CreatedAt = property.CreatedAt,
                UpdatedAt = property.UpdatedAt
            };
            _db.Properties.Add(entity);
            await _db.SaveChangesAsync();
        }

        public async Task ChangePriceAsync(Guid id, decimal newPrice)
        {
            var e = await _db.Properties.FindAsync(id);
            if (e == null) throw new KeyNotFoundException();
            e.Price = newPrice;
            e.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }

        public async Task<Property> GetAsync(Guid id)
        {
            var e = await _db.Properties.FindAsync(id);
            if (e == null) return null;
            return new Property(e.Title, e.Description, e.Price);
        }

        public async Task<IEnumerable<Property>> ListAsync(int page = 1, int size = 20)
        {
            var items = await _db.Properties.Skip((page-1)*size).Take(size).ToListAsync();
            return items.Select(e => new Property(e.Title, e.Description, e.Price));
        }

        public async Task UpdateAsync(Property property)
        {
            var e = await _db.Properties.FindAsync(property.Id);
            if (e == null) throw new KeyNotFoundException();
            e.Title = property.Title;
            e.Description = property.Description;
            e.Price = property.Price;
            e.UpdatedAt = DateTime.UtcNow;
            await _db.SaveChangesAsync();
        }
    }
}
