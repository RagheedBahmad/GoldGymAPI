using Microsoft.AspNetCore.Mvc;
using GoldGymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldGymAPI.Controllers
{
    // GET
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController(GoldGymContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Customer>> Get()
        {
            return await context.Customers.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> Get(int id)
        {
            var service = await context.Customers.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return service;
        }
        
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer employee)
        {
            context.Customers.Add(employee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer service)
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
                if (!CustomerExists(id)) // Changed from ProductExists to CustomerExists
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id) // Changed from DeleteProduct to DeleteCustomer
        {
            var service = await context.Customers.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            context.Customers.Remove(service);
            await context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool CustomerExists(int id) // Changed from ProductExists to Customer Exists
        {
            return context.Customers.Any(e => e.Id == id);
        }
    }
}

