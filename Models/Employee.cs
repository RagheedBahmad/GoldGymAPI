namespace GoldGymAPI.Models;

public class Employee
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Occupation { get; set;}
    public int Wage {get; set;}
    public bool Paid { get; set; }
}