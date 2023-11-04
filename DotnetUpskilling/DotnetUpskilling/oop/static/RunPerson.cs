namespace DotnetUpskilling.now;

public class RunPerson
{
    public void Main(string[] args)
    {
        // Person.Name = "ketsar";
        // Person ketsar = new Person
        // {
        //     Age = 17
        // };

        // Console.WriteLine($"nama saya : {Person.Name} | usia saya : {ketsar.Age}");
        // Console.WriteLine(ketsar.ToString());

        var person1 = new Person
        {
            fullName = Util.ReturnData("input your name on here : "),
            Age = 17
        };
        Console.WriteLine(person1.fullName);
        
    }
}