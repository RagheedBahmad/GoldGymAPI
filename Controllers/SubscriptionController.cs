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
        public async Task<IActionResult> AddOrUpdateSubscription(int customerId, int serviceId, DateOnly expiryDate)
        {
            var transaction = await context.Database.BeginTransactionAsync();
            var customerExists = await context.Customers.AnyAsync(c => c.Id == customerId);
            if (!customerExists)
            {
                return NotFound($"Customer with ID {customerId} not found.");
            }
            
            // Check if the service exists
            var serviceExists = await context.Services.AnyAsync(s => s.Id == serviceId);
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
                var customer = await context.Customers.FindAsync(customerId);
                service.CustomerCount++;
            }
            else
            {
                // Update the expiry date if the subscription exists
                subscription.ExpiryDate = expiryDate;
            }

            await context.SaveChangesAsync();
            await transaction.CommitAsync();
            return Ok("Post Action Successful");
            
        }
        
        [HttpDelete("{customerId}/{serviceId}")]
        public async Task<IActionResult> DeleteSubscription(int subscriptionId)
        {
            var transaction = await context.Database.BeginTransactionAsync();
            var subscription = await context.Subscriptions.FindAsync(subscriptionId);

            if (subscription == null)
            {
                return NotFound("Subscription not found.");
            }

            var service = await context.Services.FindAsync(subscription.ServiceId);
            var customer = await context.Customers.FindAsync(subscription.CustomerId);
            service.CustomerCount++;
            
            context.Subscriptions.Remove(subscription);
            await context.SaveChangesAsync();
            
            await transaction.CommitAsync();
            return NoContent();
        }
    }
}