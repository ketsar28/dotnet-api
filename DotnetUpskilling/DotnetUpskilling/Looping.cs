namespace DotnetUpskilling;

public class Looping
{
    public static void Main(string[] args)
    {
        /*
         * C# ada 3 jenis looping : (for, while, do-while)
         * for -> counted loop
         * while, do-while -> uncounted loop
         *
         * do-while : loopingnya selalu akan berjalan 1 kali walaupun kondisinya tidak memenuhi
         */
        
        // for (var i = 1; i <= 10; i++)
        // {
        //     Console.WriteLine($"for loop ke : {i}");
        // }
        //
        // Console.WriteLine("\n");
        //
        // var j = 10;
        // while (j >= 1)
        // {
        //     Console.WriteLine($"while loop ke : {j}");
        //     j--;
        // }
        //
        // var k = 0;
        // do
        // {
        //     Console.WriteLine($"do-while loop ke : {k}");
        //     
        //     k++;
        // } while (k < 5);
        
        
        // untuk melakukan input dari user, di C# bisa menggunakan object Console.ReadLine()

        Console.Write("input yout text : ");
        var inputString = Console.ReadLine(); // default : string
        Console.WriteLine($"result is : {inputString}");
        
        // convert string input become number
        Console.Write("input your number, not negative number. must be positive : ");
        var inputUnsignedInteger = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine($"result unsigned number is : {inputUnsignedInteger}");
    }
}