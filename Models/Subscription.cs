namespace GoldGymAPI.Models;

public class Subscription
{
        public int CustomerId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ExpiryDate { get; set; }
}