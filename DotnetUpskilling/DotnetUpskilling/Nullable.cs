using System.Numerics;

namespace DotnetUpskilling;

public class Nullable
{
    public void Main(string[] args)
    {
        /*
         * Nullable :
           - bisa menggunakan struct Nullable<T> = milik microsoft
           - bisa menggunakan operator optional (?)
           - C# mendukung null safety 
           misal (null safety) : 
           jika ada sebuah variable yang bernilai null, maka program akan mendeteksi,
           apakah datanya ini mau divalidasi terlebih dahulu atau tidak. jadi fitur null safety akan
           memberikan keterangan pada sebuah object/variable yang valuenya null sebelum di eksekusi
           
           - string itu secara default null, berbeda dengan string kosong ("")
           
           note : 
           - sturct bukan sebuah class
         */
        
        Nullable<int> number = null;
        Console.WriteLine(number);
        
        // cara singkat/shorthandnya dapat menggunakan operator optional (?)
        short? dataNumber = null;
        Console.WriteLine(dataNumber);
        
        // cek kondisi pada variable null
        if (number.HasValue)
        {
            Console.WriteLine(number.Value);
        }
        else
        {
            Console.WriteLine("data is empty");
        }
        
        /*
         * string.Empty; sama dengan ""
         * string data = "" - string data = string.Empty
         */
        string value = string.Empty;
        SayName(null);
    }

    static void SayName(string? name)
    {
        /*
         * selain menggunakan simbol operator perbandingan, kita juga bisa menggunaka kata
         * seperti : is not (!=), is (==), and (&&), or (||)
         */
        if (name is not null)
        {
            Console.WriteLine($"hello mas {name}");
        }
        else
        {
            Console.WriteLine("data is null");
        }
    }
}