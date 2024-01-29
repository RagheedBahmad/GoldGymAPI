namespace GoldGymAPI.Models;

public class Customer
{
    public int Id { get; set;}
    public required String Name { get; set;}
    public KeyValuePair<string, DateTime>[] Subscriptions { get; set;}
    public DateTime createdAt { get; set;}
}