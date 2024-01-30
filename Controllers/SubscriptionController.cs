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
        public async Task AddOrUpdateSubscription(int customerId, int serviceId, DateTime expiryDate)
        {
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
        }

    }
}