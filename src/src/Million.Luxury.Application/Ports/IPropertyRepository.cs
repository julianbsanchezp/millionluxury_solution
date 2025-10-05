using Million.Luxury.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Million.Luxury.Application.Ports
{
    public interface IPropertyRepository
    {
        Task<Property> GetAsync(Guid id);
        Task<IEnumerable<Property>> ListAsync(int page = 1, int size = 20);
        Task AddAsync(Property property);
        Task UpdateAsync(Property property);
        Task ChangePriceAsync(Guid id, decimal newPrice);
    }
}
