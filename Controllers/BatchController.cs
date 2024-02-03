using GoldGymAPI.Models.Batch_Requests;
using Microsoft.AspNetCore.Mvc;
// Use the correct namespace where your models are defined

// Make sure this is the correct namespace for your GoldGymContext

namespace GoldGymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BatchController(GoldGymContext context) : ControllerBase
    {
        [HttpPost("addEmployees")]
        public async Task<IActionResult> AddEmployees([FromBody] EmployeesBatchRequest request)
        {
            if (!request.Employees.Any())
            {
                return BadRequest("No employees to add.");
            }

            foreach (var employee in request.Employees)
            {
                context.Employees.Add(employee);
            }

            await context.SaveChangesAsync();
            return Ok("Batch of employees added successfully.");
        }

        [HttpPost("addCustomers")]
        public async Task<IActionResult> AddCustomers([FromBody] CustomersBatchRequest request)
        {
            if (!request.Customers.Any())
            {
                return BadRequest("No customers to add.");
            }

            foreach (var customer in request.Customers)
            {
                context.Customers.Add(customer);
            }

            await context.SaveChangesAsync();
            return Ok("Batch of customers added successfully.");
        }

        [HttpPost("addServices")]
        public async Task<IActionResult> AddServices([FromBody] ServicesBatchRequest request)
        {
            if (!request.Services.Any())
            {
                return BadRequest("No customers to add.");
            }

            foreach (var service in request.Services)
            {
                context.Services.Add(service);
            }

            await context.SaveChangesAsync();
            return Ok("Batch of services added successfully.");
        }
        
        [HttpPost("addSubscriptions")]
        public async Task<IActionResult> AddSubscriptions([FromBody] SubscriptionsBatchRequest request)
        {
            if (!request.Subscriptions.Any())
            {
                return BadRequest("No customers to add.");
            }

            foreach (var subscription in request.Subscriptions)
            {
                context.Subscriptions.Add(subscription);
            }

            await context.SaveChangesAsync();
            return Ok("Batch of Subscriptions added successfully.");
        }
    }
}