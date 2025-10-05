using System;

namespace Million.Luxury.Domain.Entities
{
    public class Property
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        private Property() { }

        public Property(string title, string description, decimal price)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Price = price;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must be >= 0");
            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
