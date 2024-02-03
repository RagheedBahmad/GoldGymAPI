namespace GoldGymAPI.Models;

public class Customer
{
    public int Id { get; set;}
    public required String Name { get; set;}
    public int Phone { get; set;}
    public DateTime CreatedAt { get; set;}
}