using GoldGymAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
// Use the correct namespace where your models are defined
// Make sure this is the correct namespace for your GoldGymContext

namespace GoldGymAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscriptionController(GoldGymContext context) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddOrUpdateSubscription(int customerId, int serviceId, DateTime expiryDate)
        {
            bool customerExists = await context.Customers.AnyAsync(c => c.Id == customerId);
            if (!customerExists)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }
            
            // Check if the service exists
            bool serviceExists = await context.Services.AnyAsync(s => s.Id == serviceId);
            if (!serviceExists)
            {
                return NotFound($"Service with ID {serviceId} not found.");
            }
            
            var subscription = await context.Subscriptions
                .FirstOrDefaultAsync(s => s.CustomerId == customerId && s.ServiceId == serviceId);

            if (subscription == null)
            {
                subscription = new Subscription
                {
                    CustomerId = customerId,
                    ServiceId = serviceId,
                    ExpiryDate = expiryDate
                };
                context.Subscriptions.Add(subscription);

                // Increment customer count for the service
                var service = await context.Services.FindAsync(serviceId);
                service.CustomerCount++;
            }
            else
            {
                // Update the expiry date if the subscription exists
                subscription.ExpiryDate = expiryDate;
            }

            await context.SaveChangesAsync();
            return Ok("Post Action Successful");
        }
        
        [HttpDelete("{customerId}/{serviceId}")]
        public async Task<IActionResult> DeleteSubscription(int customerId, int serviceId)
        {
            var subscription = await context.Subscriptions
                .FirstOrDefaultAsync(s => s.CustomerId == customerId && s.ServiceId == serviceId);

            if (subscription == null)
            {
                return NotFound("Subscription not found.");
            }

            context.Subscriptions.Remove(subscription);
            await context.SaveChangesAsync();

            return NoContent();
        }

    }
}