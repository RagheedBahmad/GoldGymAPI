using System.Data.SqlTypes;

namespace GoldGymAPI.Models;

public class Employee
{
    public int Id { get; set;}
    public string Name { get; set;}
    public string Occupation { get; set;}
    public SqlMoney Wage {get; set;}
    public Boolean Paid { get; set; }
}