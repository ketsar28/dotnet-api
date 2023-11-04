namespace DotnetUpskilling.referenceandvalue;

/*
 * tipe data primitif seperti int :
 * itu yang diambil by value, bukan berdasarkan reference/alamat memory
 *
 * berbeda dengan array : kalau array itu berdasarkan reference. jadi alamat memory langsung yang di copy
 *
 * array termasuk object
 * object pun sama, dia ini copy by reference
 *
 * passing by value : ketika ingin membuat lingkup yang berbeda dengan variable/target yang sama, sehingga alamat memorynya berbeda
 *
 * passing by reference : untuk menggunakan ini perlu menambahkan keyword 'ref' sebelum nama object/variablenya. ini digunakan ketika ingin membuat lingkup object yang sama sehingga alamatnya pun sama
 * 
 */
public class ReferenceAndValue
{
    public void Main(string[] args)
    {
        // int a = 10;
        // int b = a;
        // b = 20;
        //
        // Console.WriteLine(a);
        // Console.WriteLine(b);

        // // default version
        // int[] numbers = new[] { 1, 2, 3 };
        // int[] secondNumbers = numbers;

        // // new version - untuk menghindari copy by reference
        // var numbers = new[] { 1, 2, 3 };
        // var secondNumbers = new int[numbers.Length];
        // System.Array.Copy(numbers, secondNumbers, numbers.Length);
        //
        // Console.WriteLine($"numbers : {numbers.GetHashCode()}");
        // Console.WriteLine($"second numbers : {secondNumbers.GetHashCode()}");
        
        // secondNumbers[0] = 10;
        //
        // foreach (var number in numbers)
        // {
        //     Console.Write(number + " ");
        // }
        //
        // Console.WriteLine();
        //
        // foreach (var secondNumber in secondNumbers)
        // {
        //     Console.Write(secondNumber + " ");
        // }
        
        
        // // object pun copy by reference
        // Car ayla = new Car
        // {
        //     Brand = "toyota"
        // };
        //
        // Car avanza = ayla;
        // avanza.Brand = "honda";
        //
        // Console.WriteLine($"ayla : {ayla.GetHashCode()}");
        // Console.WriteLine($"avanza : {avanza.GetHashCode()}");

        
        // passing by value and passing by reference
        int d = 10;
        // PassingByValue(d); // mengubah nilai dari suatu variable menjadi nilai baru & berbeda (dilingkup yang berbeda)
        PassingByReference(ref d); // mengubah nilai dari suatu variable menjadi nilai yang baru & sama (dilingkup yang sama)
        Console.WriteLine($"outside of method: {d}");

    }

    public static void PassingByValue(int d)
    {
        d *= d;
        Console.WriteLine($"inside of method : {d} (passing by value)");
    }

    public static void PassingByReference(ref int d)
    {
        d *= d;
        Console.WriteLine($"inside of method : {d} (passing by reference)");
    }
}