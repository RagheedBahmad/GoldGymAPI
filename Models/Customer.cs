namespace GoldGymAPI.Models;

public class Customer
{
    public int Id { get; set;}
    public required String Name { get; set;}
    public int Phone { get; set;}
    public IEnumerable<int> SubscriptionIDs { get; set; }
    public DateTime createdAt { get; set;}
}