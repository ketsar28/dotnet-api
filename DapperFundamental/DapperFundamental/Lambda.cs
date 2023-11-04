using MySql.Data.MySqlClient;

namespace DapperFundamental;

/*
 * Lambda bisa disebut sebagai anonymous function.
 * Lambda Expression : didefinisikan sebagai anonymous function, yang artinya method/function tanpa nama
 *
 * Manfaat :
 * - supaya code lebih clean
 * - lebih mudah di baca/simple
 * - mudah di implementasikan
 *
 * terdapat 2 tipe lambda di C# :
 * 1. lambda expression : bodynya sebagai expression / langsung return one line. kodenya lebih simple (contoh : delegate()) - mirip seperti arrow function di js
 * 2. statement lambda : memiliki body (block scope) karena menampilkan kode yang lebih dari multiple line
 *
 * kalau mengembalikan nilai itu tipenya Func<int, int>
 * kalau tidak mengembalikan nilai itu tipenya Action (void)
 *
 * callback : sebuah method yang dijadikan sebuah parameter pada method lain, dan dipanggil di method lain pula
 *
 * lambda bisa digunakan berbarengan dengan LINQ
 */

public class Lambda
{
    public void Main(string[] args)
    {
        // lambda expression (anonymous function) - mirip arrow function di js
        var lambdaExpression = (int x) => x * x;
        Console.WriteLine($"result is : {lambdaExpression(2)}");

        
        // statement lambda
        var statementLambda = (Action callback) =>
        {
            Console.WriteLine("first line");
            Console.WriteLine("second line");
            callback();
        };

        
        // // dibuat function/method callbacknya terlebih dahulu
        // var callback = () =>
        // {
        //     Console.WriteLine("this is callback function by native method");
        // };
        //
        // statementLambda(callback); 
        
        
        statementLambda(() =>
        {
            Console.WriteLine("this is callback function by anonymous function");
        });
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