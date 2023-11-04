using MySql.Data.MySqlClient;

namespace DapperFundamental;

public class Program
{
    public void Main(string[] args)
    {
      
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