namespace DotnetUpskilling;

public class Array
{
    public void Main(string[] args)
    {
        /*
         * Array adalah tipe data yang dapat digunakan untuk menyimpan lebih dari 1 value
         * array indexnya dimulai dari 0 dan elementnya mulai dari 1
         * array termasuk kedalam collection, bisa menggunakan foreach untuk melakukan looping
         */
        
        // explicit declaration array
        int[] numbers = new int[3]; // dideklarasikan panjang dari arraynya

        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;
        
        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }

        
        
        numbers = new []
        {
            4, 5, 6 // tanpa dideklarasikan panjangnya, akan menyesuaikan
        };
        Console.WriteLine(numbers[0]);
        Console.WriteLine(numbers[1]);
        Console.WriteLine(numbers[2]);
        
        

        string[] personName = {"ketsar", "nabil", "kemal"};
        // personName[3] = "wahyu"; // error : index out of bounds
        
        // for (var i = 0; i < personName.Length; i++)
        // {
        //     Console.Write($"data dari index ke {i} adalah {personName[i]} \n");
        // }

        foreach (string name in personName)    
        {
            Console.WriteLine($"person name : {name}");
        }

        
        
        
        var anotherName = new IComparable[] { 1, 2, "ketsar" };
        for (var i = 0; i < anotherName.Length; i++)
        {
            Console.WriteLine($"index ke {i} : {anotherName[i]}");
        }
        
        
        
        
        /*
         * array multidimentional
         */
        
        /*
         * contoh :
         *
         * {
         *     {1, 2},
         *     {3, 4}
         * }
         */
        
        int[,] multiDimensiArrays = new int[2,2];
        multiDimensiArrays[0, 0] = 1;
        multiDimensiArrays[0, 1] = 2;
        multiDimensiArrays[1, 0] = 3;
        multiDimensiArrays[1, 1] = 4;

        // cara akses 1
        Console.WriteLine($" (manual) : {multiDimensiArrays[0, 0]}");
        Console.WriteLine($" (manual) : {multiDimensiArrays[0, 1]}");
        Console.WriteLine($" (manual) : {multiDimensiArrays[1, 0]}");
        Console.WriteLine($" (manual) : {multiDimensiArrays[1, 1]}");

        // cara akses 2
        for (var i = 0; i < 2; i++)
        {
            for (var j = 0; j < 2; j++)
            {
                
                Console.WriteLine($"(for) datanya : {multiDimensiArrays[i, j]}");
            }
        }

        // cara akses 3 - GetLength() : akses dimensinya
        for (int i = 0; i < multiDimensiArrays.GetLength(0); i++)
        {
            for (int j = 0; j < multiDimensiArrays.GetLength(1); j++)
            {
                Console.WriteLine($"(foreach) datanya : {multiDimensiArrays[i, j]}");
            }
        }
        
        
        // datanya langsung di inisialisasi
        var secondMultiDimensionalArray = new int[3, 2]
        {
            {1,2},
            {3,4},
            {5,6}
        };

        for (int i = 0; i < secondMultiDimensionalArray.GetLength(0); i++)
        {
            for (int j = 0; j < secondMultiDimensionalArray.GetLength(1); j++)
            {
                Console.WriteLine($"(foreach - second multi array dimensi) datanya : {secondMultiDimensionalArray[i, j]}");
            }
        }
    }
}