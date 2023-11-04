using DapperFundamental.entity;

namespace DapperFundamental;

/*
 * LINQ : (Language Integrated Query) ini sama seperti query sql pada umumnya. tetapi kita hanya bisa memakai query DQL (select). kita bisa menggunakan LINQ di bahasa pemrograman yang mendukung dotnet (C# dan VB). digunakan untuk melakukan query berbagai macam data (SQL, XML, Memory Object (Collection)). LINQ ini bisa melakukan konversi secara otomatis ke berbagai data source
 *
 * LINQ mendukung banyak data source :
 * - In Memory Object (List, Array)
 * - Entity Framework
 * - SQL Server
 * - XML Document (Old Document)
 * - Data Source Lainnya
 *
 * LINQ bisa menghubungkan ke berbagai data source yang diprovide olehnya, karena dia didalamnya memiliki LINQ Provider. LINQ Provider ini mengkonversi di tengah". 
 * LINQ Provider :
 * - LINQ to Objects
 * - LINQ to Entities
 * - LINQ to XML
 * - LINQ to SQL
 * - LINQ to DataSet
 * - dsb
 *
 * process :
 * 1. query -> 2. provider -> 3. datasource
 *
 * ada 3 hal untuk membuat query LINQ :
 * 1. datasource (data mentah dari : -> ) (SQL, In Memory Object, XML)
 * 2. query (select ... )
 * 3. Execution of the Query
 *
 * Kombinasi query yang perlu diketahui :
 * - Query Syntax
 * - Method Syntax
 * - Mixed Syntax
 *
 * Query Syntax :
 * from object in datasource - inisialisasi
 * where condition - kondisi
 * select object - seleksi
 *
 * Method Syntax :
 * Datasource.ConditionMethod().SelectionMethod()
 * inisialisasi - kondisi - seleksi
 *
 * extension method : method tambahan yang ditempelkan di class lain, tanpa harus merubah isi secara langsung classnya
 */

public class LinQ
{
    public static void Main(string[] args)
    {
        // // query sintaks - numbers -> data source
        // var nums = new List<int> { 1,2,3,4,5,6,7,8,9,10 };
        // var filterNumber = 
        //     from num in nums
        //     where num <= 5
        //     orderby number descending
        //     select num;
        //
        // foreach (var data in filterNumber) Console.Write($"{data} ");
        // Console.WriteLine();
        
        
        // method sintaks - lambda expression
        // untuk mendefinisikan query si LINQ, jadi lebih mudah di baca
        var nums = new List<int> { 1,2,3,4,5,6,7,8,9,10 };
        var evenNumbers = nums.Where((num) => num % 2 == 0).OrderByDescending(i => i);
        
        Console.WriteLine("results are : ");
        foreach (var number in evenNumbers) Console.WriteLine($"- {number}");

        
        // // query sintaks  - product
        // var products = new List<Product>()
        // {
        //     new() {Id = 7, ProductName = "Bantal", ProductPrice = 30000, Stock = 12},
        //     new() {Id = 8, ProductName = "Guling", ProductPrice = 35000, Stock = 15},
        //     new() {Id = 9, ProductName = "Televisi", ProductPrice = 3500000, Stock = 15},
        //     new() {Id = 10, ProductName = "Bacin", ProductPrice = 85000, Stock = 15},
        //
        // };
        //
        // var findProductByName =
        //     from product in products
        //     orderby product.ProductName descending 
        //     select product.ProductName;
        //
        // Console.WriteLine("results are : ");
        // foreach (var product in findProductByName)
        // {
        //     Console.WriteLine($"* {product}");
        // }
        //
        
        
        // method sintaks - product
        var products = new List<Product>()
        {
            new() {Id = 7, ProductName = "Bantal", ProductPrice = 30000, Stock = 12},
            new() {Id = 8, ProductName = "Guling", ProductPrice = 35000, Stock = 15},
            new() {Id = 9, ProductName = "Televisi", ProductPrice = 3500000, Stock = 15},
            new() {Id = 10, ProductName = "Bacin", ProductPrice = 85000, Stock = 15},
        
        };
        var findProductNameByMethodSyntax= products.Where(product => product.ProductPrice > 50000).Select(product => product.ProductName);
        
        Console.WriteLine("results are : ");
        foreach (var product in findProductNameByMethodSyntax)
        {
            Console.WriteLine($"* {product}");
        }
        
        
        // pagination menggunakan LINQ
        var page = 2;
        var size = 2;
        
        var paging = products.Page(page, size);
            Console.WriteLine($"page : {page}");
        foreach (var product in paging) Console.WriteLine($"data : {product}");
        
        
        // // mixed sintaks - product
        // var products = new List<Product>()
        // {
        //     new() {Id = 7, ProductName = "Bantal", ProductPrice = 30000, Stock = 12},
        //     new() {Id = 8, ProductName = "Guling", ProductPrice = 35000, Stock = 15},
        //     new() {Id = 9, ProductName = "Televisi", ProductPrice = 3500000, Stock = 15},
        //     new() {Id = 10, ProductName = "Bacin", ProductPrice = 85000, Stock = 15},
        //
        // };
        // var filterProductByMixedSyntax =
        //     (from product in products
        //         where product.ProductPrice is > 30000 and < 100000
        //         select product).OrderByDescending(p => p.ProductName);
        //
        // foreach (var product in filterProductByMixedSyntax) Console.WriteLine(product);


        // // extention method
        // var a = 10;
        // var plus = a.Plus(20);
        // Console.WriteLine($"result a now is : {plus}");
    }
}

public static class MyExtensionMethod
{
    // // harus mengembalikan tipe data integer
    // public static int Plus(this int value, int parameter)
    // {
    //     return value + parameter;
    // }

    public static IEnumerable<T> Page<T>(this IEnumerable<T> dataSource, int page, int size)
    {
        return dataSource.Skip((1 - page) * size).Take(size);
    }
}