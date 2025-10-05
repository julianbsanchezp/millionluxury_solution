using Million.Luxury.Domain.Entities;

namespace Million.Luxury.Application.Ports
{
    public interface IPropertyRepository
    {
        Task<Property> AddAsync(Property property);
        Task<List<Property>> GetAllAsync();
        Task<Property?> GetByIdAsync(Guid id);
        Task UpdateAsync(Property property);
        Task DeleteAsync(Guid id);
    }
}
