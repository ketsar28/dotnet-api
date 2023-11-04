using Dapper;
using DapperFundamental.entity;
using MySql.Data.MySqlClient;

namespace DapperFundamental;
/*
 * Dapper : open source object relational mapping (ORM), tapi tidak sepenuhnya ORM. sebenarnya dia hanya object mapping saja, tidak ada relationalnya. gunanya untuk melakukan mapping
 *
 * kenapa pakai Dapper ?
 * - ringan dan cepat, lebih cepat dalam mengakses data
 * - karena mudah digunakan dan object mapping yang powerful
 * - bisa menggunakan native query. masih menggunakan mysql
 * - mendukung yang namanya parameterized queries yang membantu kita untuk menghindari yang namanya SQL injection
 *
 * tujuan utama dari dapper : untuk melakukan mapping query ke object
 *
 * Dapper adalah ORM (micro ORM) yang memungkinkan kita untuk mengakses data lebih cepat dan melakukan mapping data
 *
 * Dapper RDBMS (Provider) : SQL Server, Oracle, PostgreSQL, MySQL
 * Extention Method : membuat function/method dalam suatu class tanpa merubah isi dari class tersebut
 *
 * note :
 * kalau pake dapper, harus menggunakan ADO.Net. harus ada drivernya (ADO.Net, ada di NuGet di toolbar)
 * kenapa membutuhkan ADO.Net ? karena dapper hanya menyediakan extention method
 *
 */

/*
 * 4 method extention IDBConnection :
 * - Query (DQL) - mengembalikan data (select)
 * - Execute (DDL, DML) - mengembalikan 1 row - (mirip seperti Stream<> di java)
 * - ExecuteScalar (DMl, DQL) - hanya mengembalikan satu column di satu record
 * - ExecuteReader (DQL)
 *
 * IEnumerable(return Query()) -> operasi LINQ (bahasa Query yang bisa digunakan di C#)
 * DefaultTypeMap.MatchNamesWithUnderscores = true; : untuk melakukan mapping antara naming convention PascalCase(entity) dan snack_case(database)
 *
 * untuk menampilkan satu data :
 * - QuerySingle - Dynamic : mengembalikan satu data - Exception saat query kosong atau data bisa lebih dari satu
 * - QuerySingle<T>
 * - QuerySingleOrDefault - Dynamic : mengembalikan satu data - Exception saat query menampilkan lebih dari satu data, kalau query kosong akan return null
 * - QuerySingleOrDefault<T>
 * - QueryFirst - Dynamic : mengembalikan satu data - Exception saat query kosong
 * - QueryFirst<T>
 * - QueryFirstOrDefault - Dynamic : mengembalikan satu data - tidak mengembalikan exception, kalau query kosong akan return null
 * - QueryFirstOrDefault<T>
 *
 *
 * Parameterized Dapper :
 * - anonymous parameters : kita handle manual
 * - dynamic parameters : dihandle sama dappernya, karena punya objects sendiri
 */

public class Program
{
    public static void Main(string[] args)
    {
        // implementasi  dari IDBConnection
        var connect = DbConfigurationGeneral();
        var connection = ToConnectDatabase(connect);
        DefaultTypeMap.MatchNamesWithUnderscores = true;

        
        // // sql create table
        // var sql = @" 
        //             create table m_product 
        //             (
        //                 id int primary key auto_increment,
        //                 product_name varchar(100),
        //                 product_price bigint,
        //                 stock int
        //             )";
        
        
        // // sql insert
        // var sql = @"insert into m_product(product_name, product_price, stock)
        //             values ('indomie', 5000, 5),
        //                    ('milku', 3000, 8),
        //                    ('bon cabe', 4000, 12);";

        
        // // sql select all
        // var sql = "select * from m_product";
        
        
        // // sql select single data
        // var sql = "select * from m_product where product_price < 9000";
        
        
        // // sql select single column and single record
        // var sql = "select product_name from m_product";
        
        
        // // sql select all data with data reader
        // var sql = "select * from m_product";


        
        
        // // using dapper - Execute() - insert data
        // var execute = connection.Execute(sql);
        // if (execute > 0)
        // {
        //     Console.WriteLine("data entered successfully");
        // }


        // // using native ADO.Net - insert data
        // connection.Open();
        // var query = new MySqlCommand(sql, connection);
        // query.ExecuteNonQuery();


        // // using dapper - Query() (mirip seperti Stream<> di java) - select all
        // var select = connection.Query<Product>(sql).ToList();
        //
        // // IEnumerable(return Query()) -> operasi LINQ (bahasa Query yang bisa digunakan di C#) 
        //
        // foreach (var product in select)
        // {
        //     Console.WriteLine(product);
        // }


        // // using dapper - QuerySingle() - select single data
        // var single = connection.QueryFirstOrDefault<Product>(sql);
        // if (single is null)
        // {
        //     Console.WriteLine("nothing data");
        // }
        // Console.WriteLine(single);


        // // using dapper - ExecuteScalar() - select single column and single record
        // var query = connection.ExecuteScalar<string>(sql);
        // Console.WriteLine($"data pertama : {query}");


        // // using dapper - ExecuteReader() - select all data with data reader
        // var data = connection.ExecuteReader(sql);
        // while (data.Read())
        // {
        //     Product product = new Product()
        //     {
        //         Id = Convert.ToInt32(data["id"]),
        //         ProductName = data["product_name"].ToString(),
        //         ProductPrice = Convert.ToInt64(data["product_price"]),
        //         Stock = Convert.ToInt32(data["stock"])
        //     };
        //
        //     Console.WriteLine(product);
        // }
        
        
        
        
        // // parameterized dapper - avoid to sql injection happening
        
        
        // // anonymous parameter with anonymous object
        // var product = new Product()
        // {
        //     ProductName = "Celana",
        //     ProductPrice = 35000,
        //     Stock = 10
        // };
        //
        // var sql = "insert into m_product(product_name, product_price, stock) values(@productName, @productPrice, @stock)";
        //
        // var parameters = new
        // {
        //     productName = product.ProductName,
        //     productPrice = product.ProductPrice,
        //     stock = product.Stock
        // };
        //
        // var execute = connection.Execute(sql, parameters);
        // var isSuccess = execute > 0 ? "data success to entered" : "sorry, probably your query is incorrect";
        // Console.WriteLine(isSuccess);
        
        
        // // dynamic parameters - dihandle sama dappernya, karena punya objects sendiri
        //
        // var sql = "insert into m_product(product_name, product_price, stock) values(@productName, @productPrice, @stock)";
        // var product = new Product()
        // {
        //     ProductName = "Laptop",
        //     ProductPrice = 6500000,
        //     Stock = 41
        // };
        // var dynamicParameters = new DynamicParameters(product);
        // var execute = connection.Execute(sql, dynamicParameters);
        // // var execute2 = connection.Execute(sql, product);
        // var isSuccess = execute > 0 ? "success" : "failed";
        // Console.WriteLine(isSuccess);
        //x
        // var sql = "select * from m_product where product_price >= @price";
        // var products = connection.Query<Product>(sql, new {price = 35000}).ToList();
        // products.ForEach(Console.WriteLine);
    }

     private static string DbConfigurationGeneral()
    {
        const string localhost = "localhost";
        const string port = "3306";
        const string user = "root";
        const string password = "";
        const string database = "dotnet_dapper";
        const string connection = $"server={localhost};port={port};uid={user};pwd={password};database={database}";
        return connection;
    }

     private static MySqlConnection ToConnectDatabase(string connect)
     {

         using var connection = new MySqlConnection(connect);
         connection.Open();
         Console.WriteLine("database successfully connected");
         return connection;
     }
}