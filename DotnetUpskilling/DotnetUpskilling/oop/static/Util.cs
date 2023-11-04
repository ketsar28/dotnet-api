namespace DotnetUpskilling.now;

public class Util
{
    public static string ReturnData(string info)
    {
        while (true)
        {
            Console.Write($"{info}");
            var inputName = Console.ReadLine();
            if (string.IsNullOrEmpty(inputName)) continue;
            return $"my full name is {inputName}";
        }
    }
    
    
    
}