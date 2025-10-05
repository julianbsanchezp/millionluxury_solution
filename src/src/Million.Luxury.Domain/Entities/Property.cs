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
            Title = !string.IsNullOrWhiteSpace(title) ? title : throw new ArgumentException("Title required");
            Description = description;
            Price = price >= 0 ? price : throw new ArgumentException("Price must be >=0");
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ChangePrice(decimal newPrice)
        {
            if (newPrice < 0) throw new ArgumentException("Price must be >= 0");
            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public void Update(string title, string description)
        {
            Title = title ?? Title;
            Description = description ?? Description;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
