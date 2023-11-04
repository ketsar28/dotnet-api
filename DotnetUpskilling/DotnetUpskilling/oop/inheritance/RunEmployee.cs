namespace DotnetUpskilling.now;

public class RunEmployee
{
    public void Main(string[] args)
    {
        Employee employee1 = new Employee
        {
            Name = "ketsar"
        };
        Manager manager1 = new Manager
        {
            Name = "nabil"
        };
        
        manager1.SayEmployee(employee1);

        Employee supervisor1 = new Supervisor
        {
            Name = "kemal"
        };
        
        supervisor1.SayEmployee(manager1);
    }
}