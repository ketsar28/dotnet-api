namespace DotnetUpskilling.now;

public class Employee
{
    public string id { get; set; }
    public string Name { get; set; }
    public string Devision { get; set; }

    /*
     * bukan termasuk pewarisan / method overloading
     */
    public virtual void SayEmployee(Employee employee)
    {
        Console.WriteLine($"Hi {employee.Name} (employee)");
    }
}