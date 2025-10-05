using System.Net.Http.Json;
using FluentAssertions;
using Million.Luxury.Domain.Entities;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Million.Luxury.Tests
{
    public class PropertiesApiTests
    {
        private readonly HttpClient _client;

        public PropertiesApiTests()
        {
            var application = new WebApplicationFactory<Program>();
            _client = application.CreateClient();
        }

        [Fact]
        public async Task PostProperty_ShouldReturnCreatedProperty()
        {
            // Arrange
            var newProperty = new
            {
                title = "Apartamento en Bogotá",
                description = "Zona norte, 3 habitaciones",
                price = 450000000
            };

            // Act
            var response = await _client.PostAsJsonAsync("/api/properties", newProperty);

            // Assert
            response.EnsureSuccessStatusCode();
            var property = await response.Content.ReadFromJsonAsync<Property>();

            property.Should().NotBeNull();
            property!.Title.Should().Be("Apartamento en Bogotá");
            property.Price.Should().Be(450000000);
        }

        [Fact]
        public async Task GetProperties_ShouldReturnList()
        {
            // Arrange -> primero crear una propiedad
            var newProperty = new
            {
                title = "Propiedad test",
                description = "Propiedad de prueba",
                price = 1000000
            };
            await _client.PostAsJsonAsync("/api/properties", newProperty);

            // Act -> luego consultar el listado
            var response = await _client.GetAsync("/api/properties");

            // Assert
            response.EnsureSuccessStatusCode();
            var properties = await response.Content.ReadFromJsonAsync<List<Property>>();

            properties.Should().NotBeNull();
            properties!.Count.Should().BeGreaterThan(0); // ahora sí hay mínimo 1
        }
    }
}
