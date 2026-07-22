
namespace backend.Models;
public class Employee
{
    public int id {get; set;}
    public string name {get; set;}=string.Empty;
    public string department {get; private set;}=string.Empty;
    public decimal salary {get; private set;}
}