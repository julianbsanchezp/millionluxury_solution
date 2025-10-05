using Microsoft.AspNetCore.Mvc;
using Million.Luxury.Application.Ports;
using Million.Luxury.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Million.Luxury.Api.Controllers
{
    [ApiController]
    [Route("api/properties")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _repo;

        public PropertiesController(IPropertyRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePropertyDto dto)
        {
            var property = new Property(dto.Title, dto.Description, dto.Price);
            await _repo.AddAsync(property);
            return CreatedAtAction(nameof(Get), new { id = property.Id }, property);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var prop = await _repo.GetAsync(id);
            if (prop == null) return NotFound();
            return Ok(prop);
        }

        [HttpPut("{id}/price")]
        public async Task<IActionResult> ChangePrice(Guid id, [FromBody] ChangePriceDto dto)
        {
            await _repo.ChangePriceAsync(id, dto.NewPrice);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int page = 1, [FromQuery] int size = 20)
        {
            var list = await _repo.ListAsync(page, size);
            return Ok(list);
        }
    }

    public record CreatePropertyDto(string Title, string Description, decimal Price);
    public record ChangePriceDto(decimal NewPrice);
}
