using Microsoft.EntityFrameworkCore;
using Million.Luxury.Application.Ports;
using Million.Luxury.Domain.Entities;

namespace Million.Luxury.Infrastructure.Repositories
{
    public class SqlPropertyRepository : IPropertyRepository
    {
        private readonly AppDbContext _context;

        public SqlPropertyRepository(AppDbContext context)
        {
            _context = context;
        }

        // Crear una nueva propiedad
        public async Task<Property> AddAsync(Property property)
        {
            await _context.Properties.AddAsync(property);
            await _context.SaveChangesAsync();
            return property;
        }

        // Obtener todas las propiedades
        public async Task<List<Property>> GetAllAsync()
        {
            return await _context.Properties.ToListAsync();
        }

        // Buscar propiedad por Id (puede no existir)
        public async Task<Property?> GetByIdAsync(Guid id)
        {
            return await _context.Properties.FindAsync(id);
        }

        // Actualizar propiedad existente
        public async Task UpdateAsync(Property property)
        {
            _context.Properties.Update(property);
            await _context.SaveChangesAsync();
        }

        // Eliminar propiedad por Id
        public async Task DeleteAsync(Guid id)
        {
            var property = await _context.Properties.FindAsync(id);
            if (property != null)
            {
                _context.Properties.Remove(property);
                await _context.SaveChangesAsync();
            }
        }
    }
}
