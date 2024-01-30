using GoldGymAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// Use the correct namespace where your models are defined

// Make sure this is the correct namespace for your GoldGymContext

namespace GoldGymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Prefix with "api/" if that's your desired routing structure
    public class ServiceController(GoldGymContext context) : ControllerBase
    {
        // Add a constructor to inject the context

        // GET: api/Service
        [HttpGet]
        public async Task<List<Service>> Get()
        {
            return await context.Services.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> Get(int id)
        {
            var service = await context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return service;
        }
        
        // POST: api/Service
        [HttpPost]
        public async Task<ActionResult<Service>> PostService(Service service)
        {
            context.Services.Add(service);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = service.Id }, service);
        }

        // PUT: api/Service/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutService(int id, Service service)
        {
            if (id != service.Id)
            {
                return BadRequest();
            }

            context.Entry(service).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceExists(id)) // Changed from ProductExists to ServiceExists
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/Service/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id) // Changed from DeleteProduct to DeleteService
        {
            var service = await context.Services.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            context.Services.Remove(service);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceExists(int id) // Changed from ProductExists to ServiceExists
        {
            return context.Services.Any(e => e.Id == id);
        }
    }
}