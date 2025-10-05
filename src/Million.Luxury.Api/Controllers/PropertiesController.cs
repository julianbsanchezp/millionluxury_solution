using Microsoft.AspNetCore.Mvc;
using Million.Luxury.Application.Ports;
using Million.Luxury.Domain.Entities;

namespace Million.Luxury.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyRepository _repository;

        public PropertiesController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        // POST: api/properties
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Property property)
        {
            var created = await _repository.AddAsync(property);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // GET: api/properties
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var properties = await _repository.GetAllAsync();
            return Ok(properties);
        }

        // GET: api/properties/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var property = await _repository.GetByIdAsync(id);
            if (property == null) return NotFound();
            return Ok(property);
        }

        // PUT: api/properties/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Property updated)
        {
            var property = await _repository.GetByIdAsync(id);
            if (property == null) return NotFound();

            property.ChangePrice(updated.Price); // actualizamos el precio
            await _repository.UpdateAsync(property);

            return NoContent();
        }

        // DELETE: api/properties/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var property = await _repository.GetByIdAsync(id);
            if (property == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}
