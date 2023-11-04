namespace DotnetUpskilling;

public class Method
{
    public void Main(string[] args)
    {
        /*
         * METHOD :
         *
         * naming convention untuk sebuah method di C# : PascalCase
         */

        // tidak mengembalikan nilai - void
        SayHelloWorld();
        
        // tidak mengembalikan nilai dengan parameter - void
        SayYourHobby(new string[]{"football", "basketball"});

        // mengembalikan nilai dengan parameter - return (data type)
        var personName = SayPersonName("ketsar");
        Console.WriteLine(personName);
        
        // mengembalikan nilai dengan multiple parameters - return (data type)
        var calculateNumbers = CalculateNumbers(2,8);
        var calculateNumbers2 = CalculateNumbers(20,8);

        Console.WriteLine($"first result is : {calculateNumbers} | " +
                          $"second result is : {calculateNumbers2}");
        
        
        // anonymous function/method (local)
        var printData = delegate(string name)
        {
            Console.WriteLine($"this is anonymouns method ({name})");
        };

        var printDataLamda = () =>
        {
            // like arrow function in javascript
            Console.WriteLine("this is anonymous method with lambda");
        };

        printData("ketsar");
        printDataLamda();
    }
    
    /*
     * STRUKTUR PEMBUATAN METHOD DI C# :
     * 
     * access modifier : lingkup dari sebuah method untuk dapat di akses
     * static/non-static
     * return/void
     * void : melakukan operasi didalamnya, namun tidak mengembalikan nilainya
     * 
     */

    static void SayHelloWorld()
    {
        Console.WriteLine("Hello World!");
    }

    static void SayYourHobby(string[] hobbies)
    {
        foreach (var hobby in hobbies)
        {
            Console.WriteLine($"my hobby is : {hobby}");   
        }
    }

    static string SayPersonName(string person)
    {
        return $"hello {person}. semangat ya belajar C# nya...";
    }

    static int CalculateNumbers(int a, int b)
    {
        int endResult = a + b;
        return endResult;
    }
}