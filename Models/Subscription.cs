namespace GoldGymAPI.Models;

public class Subscription
{
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public DateOnly ExpiryDate { get; set; }
}