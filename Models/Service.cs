namespace GoldGymAPI.Models;

public class Service
{
    public int Id {get; set; }
    public required String Name {get; set; }
    public int Price {get; set; }
    public int CustomerCount { get; set; } 
}