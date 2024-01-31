using Microsoft.AspNetCore.Mvc;
using GoldGymAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GoldGymAPI.Controllers
{
    // GET
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController(GoldGymContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<List<Employee>> Get()
        {
            return await context.Employees.ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            var service = await context.Employees.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            return service;
        }
        
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
            context.Employees.Add(employee);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int id, Employee service)
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
                if (!EmployeeExists(id)) // Changed from ProductExists to EmployeeExists
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id) // Changed from DeleteProduct to DeleteEmployee
        {
            var service = await context.Employees.FindAsync(id);
            if (service == null)
            {
                return NotFound();
            }

            context.Employees.Remove(service);
            await context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool EmployeeExists(int id) // Changed from ProductExists to Employee Exists
        {
            return context.Employees.Any(e => e.Id == id);
        }
    }
}

