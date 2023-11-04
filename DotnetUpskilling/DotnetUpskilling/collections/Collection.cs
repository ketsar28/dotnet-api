using System.Collections;
using System.Data;

namespace DotnetUpskilling.collections;

/*
 * collection : mirip seperti array, memiliki variasi dari collection.
 *
 * keunggulan dari collection :
 * - bisa menambah data secara terus menerus/secara dinamis
 * - bisa mengoperasikan CRUD (create (save), update, delete, retrieve, sort (get))
 *
 * tipe collecion di C# :
 * - generic (System.Collections.Generic)
 * - collection class (not recommended)
 * - async web
 *
 * jenis-jenis collection :
 * - List ^
 * - Stack (tumpukan)
 * - Queue (barisan)
 * - LinkedList
 * - HashSet ^
 * - SortedSet ^
 * - Dictionary ^ 
 * - SortedDictionary ^
 * - SortedSet ^
 *
 * List : ini mirip seperti array, bedanya List lebih flexible dan lebih mudah dioperasikan CRUD
 * HastSet : untuk menyimpan kumpulan data, dan hanya menyimpan unique value. dia hanya mendapatkan dan menghapus data, tidak bisa di update
 * Hashtable : yang menyimpan datanya berupa pasangan key dan value (seperti json), kalau ini tidak menentukan tipenya sehingga tidak generic (cara lama)
 * Dictionary : yang menyimpan datanya berupa pasangan key dan value (seperti json), bedanya ini harus menentukan tipenya (untuk key dan valuenya) dan ini generic jadi harus unique - lebih strict(cara baru)
 */

public class Collection
{
    public void Main(string[] args)
    {
       // ListManipulation();
       // ChangeTheCityNameInList();
       // LoopDataInHashSet();
       // HashSetManipulationData();
       // HashtableManipulation();
       // DictionaryManipulation();
       // PrintElementSortedList();
       // PrintElementSortedDictionary();
       // PrintElementSortedSet();
    }

    private static void ListManipulation()
    {
        List<int> numbers = new List<int>();
        numbers.Add(1);
        numbers.Add(2);
        
        for (var i = 0; i < numbers.Count; i++)
        {
            Console.WriteLine($"index ke-{i} : {numbers[i]}");
        }
        
        // initiate langsung
        var strs = new List<string>
        {
            "jakarta",
            "bandung",
            "samarinda"
        };
        
        foreach (var str in strs)
        {
            Console.WriteLine($"data kota : {str}");
        }
        for (var i = 0; i < strs.Count; i++)
        {
            Console.WriteLine($"hasil strs : {strs[i]}");
        }
        
        // update element by index
        Console.WriteLine(strs[0]);
        strs[0] = "bogor";
        Console.WriteLine(strs[0]);
        
        // remove collection list
        strs.RemoveAt(0);
        strs.Remove("bandung");
        Console.WriteLine(strs.Count);
        
        
        foreach (var str in strs)
        {
            Console.WriteLine($"data kota : {str}");
        }
    }

    private static void ChangeTheCityNameInList()
    {
        var strs = new List<string>
        {
            "jakarta",
            "bandung",
            "samarinda"
        };


        Console.WriteLine("there are cities in indonesia");
        for (var i = 0; i < strs.Count; i++)
        {
            var city = strs[i];
            Console.WriteLine($"{i + 1}. : {city}");
        }
        
        Console.Write("input your number of the city you want to change : ");
        var number = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        
          
        for (var i = 0; i < strs.Count; i++)
        {
            if (i != number - 1) continue;
            Console.Write("what name the city do you change : ");
            var update = Console.ReadLine();
            strs[i] = update ?? string.Empty;
        }
        
        foreach (var city in strs)
        {
            Console.WriteLine($"final : {city}");
        }
    }

    private static void LoopDataInHashSet()
    {
        var person = new HashSet<string>
        {
            "ketsar", "nabil", "ketsar", "kemal"
        };

        foreach (var name in person)
        {
            Console.Write($"{name} ");
        }
    }

    private static void HashSetManipulationData()
    {
        var person = new HashSet<string>
        {
            "ketsar", "nabil", "ketsar", "kemal", "kemal", "kemil"
        };
        
        // // remove by name
        // person.Remove("nabil");
        // foreach (var name in person) Console.Write($"{name} ");

        
        // remove all by condition (name)
        person.RemoveWhere(who => who.Contains("kem"));
        foreach (var name in person) Console.Write($"{name} ");
    }

    private static void HashtableManipulation()
    {
        var dataHashtable = new Hashtable
        {
            {1, "bandung"},
            {"2", 100},
            {true, false}
        };

        Console.WriteLine("real data : ");
        foreach (DictionaryEntry data in dataHashtable)  Console.WriteLine($"key : {data.Key} - value : {data.Value}");
        Console.WriteLine();

        // update data in hashtable
        dataHashtable[true] = "javascript";
        dataHashtable = new Hashtable
        {
            {1, "bogor"},
            {"2", "listening to shalawat"},
            {true, 700}
        };

        Console.WriteLine("after update : ");
        foreach (DictionaryEntry data in dataHashtable)  Console.WriteLine($"key : {data.Key} - value : {data.Value}");
        Console.WriteLine();
        
        // remove hashtable element
        dataHashtable.Remove("2");
        Console.WriteLine("after remove : ");
        foreach (DictionaryEntry data in dataHashtable)  Console.WriteLine($"key : {data.Key} - value : {data.Value}");
        Console.WriteLine();
        
    }

    private static void DictionaryManipulation()
    {
        var cities = new Dictionary<int, string>();
        cities.Add(1, "jakarta");
        cities.Add(2, "bogor");

        Console.WriteLine("real data : ");
        foreach (var city in cities) Console.WriteLine($"key : {city.Key} - value : {city.Value}");
        Console.WriteLine();
        
        // remove some element dictionary
        cities.Remove(1);
        
        Console.WriteLine("after remove : ");
        foreach (var city in cities) Console.WriteLine($"key : {city.Key} - value : {city.Value}");
        Console.WriteLine();
    }

    private static void PrintElementSortedList()
    {
        var elements = new SortedList
        {
            {1, "jakarta"},
            {3, "bogor"},
            {5, false}
        };

        foreach (DictionaryEntry element in elements) Console.WriteLine($"{element.Key} - {element.Value}");
    }

    private static void PrintElementSortedDictionary()
    {
        var elements = new SortedDictionary<string, string>
        {
            {"satu", "javascript"},
            {"dua", "java"},
            {"tiga", "dotnet (C#)"}
        };
        foreach (var element in elements) Console.WriteLine($"{element.Key} - {element.Value}");
    }

    private static void PrintElementSortedSet()
    {
        var elements = new SortedSet<string>
        {
            "java", "javascript", "ruby", "dotnet", "dotnet" 
        };

        foreach (var element in elements) Console.WriteLine($"{element}");
    }
}