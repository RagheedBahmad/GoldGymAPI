using Microsoft.AspNetCore.Mvc;
namespace GoldGymAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GoldGymAPI.Models; // Use the correct namespace where your models are defined
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")] // This sets up the base route for this controller
public class ServiceController(GoldGymContext context) : ControllerBase
{
    // Add action methods here
    public async Task<ActionResult<IEnumerable<Service>>> GetServices()
    {
        return await context.Services.ToListAsync();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduct(int id, Service service)
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
            if (!ProductExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }
    // DELETE: api/Product/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await context.Services.FindAsync(id);
        if (product == null)
        {
            return NotFound();
        }

        context.Services.Remove(product);
        await context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProductExists(int id)
    {
        return context.Services.Any(e => e.Id == id);
    }

}
