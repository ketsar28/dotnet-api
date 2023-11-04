namespace DotnetUpskilling.exception;

/*
 * error dibagi menjadi beberapa jenis :
 * 1. runtime exception : saat menuliskan sintaks, dan itu benar. namun ada yellow/red underline dari sintaks tersebut
 * 2. syntax exception
 * 3. compile exception
 * 
 * exception handling : bagaimana cara kita untuk menangani error/teknik untuk nge-handle error yang terjadi, supaya program yang dibuat itu dapat berjalan secara normal
 *
 * contoh exception di C# :
 * DivideByZeroException
 * NullReferenceException
 *
 * keyword yang digunakan :
 * try, catch, finally, throw
 *
 * note :
 * keyword throw : salah satu untuk memberhentikan sebuah method dan juga program
 * 
 */

public class ExceptionHandling
{
    public static void Main(string[] args)
    {
        Console.Write("input first number : ");
        var a = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        Console.Write("input second number : ");
        var b = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

        // ConsoleMessageException(a, b);
        // ThrowMessageException(a, b);
        // FinallyInTryCatch(a, b);
        // PrintResultOfName();
      
    }

    private static void ConsoleMessageException(int a, int b)
    {
        try
        {
            var operation = a / b;
            Console.WriteLine($"the result is {operation}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message); // mencetak pesan errornya aja
            Console.WriteLine(e); // mencetak seluruh detail dari error tersebut termasuk line keberapanya
        }
    }

    private static void ThrowMessageException(int a, int b)
    {
        try
        {
            var operation = a / b;
            Console.WriteLine($"the result is {operation}");
        }
        catch (Exception e)
        {
            // // diclaimer : kalau kita melakukan 'throw' maka kode setelahnya walaupun tidak error itu tidak akan dijalankan, jadi programnya akan terhenti sampai situ aja. tetapi kalau tidak menggunakan 'throw' hanya cetak biasa, kode setelahnya akan tetap dijalankan
            
            // cara pertama
            Console.WriteLine(e);
            throw;

            // // cara kedua
            // throw new Exception(e.Message);
        }
    }

    private static void FinallyInTryCatch(int a, int b)
    {
        try
        {
            var operation = a / b;
            Console.WriteLine($"the result is {operation}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            Console.WriteLine("this is finally()");
        }
    }

    private static string FindByName()
    {
        var names = new List<string>()
        {
            "ketsar", "nabil", "irwan", "kemal"
        };

        Console.Write("who's your find : ");
        var input = Console.ReadLine();
        string? temp = null;
        
        foreach (var name in names)
        {
            if (!name.Equals(input)) continue;
            temp = name;
        }

        if (temp is null) throw new Exception($"{input} not found");

        return $"i was find {temp}";
    }

    private static void PrintResultOfName()
    {
        // nested try-catch
        try
        {
            try
            {
                Console.WriteLine(FindByName());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(FindByName());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("after try catch");
    }
}