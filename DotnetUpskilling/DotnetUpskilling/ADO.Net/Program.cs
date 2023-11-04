
using System.Diagnostics;
using DotnetUpskilling.ADO.Net.Entity;
using DotnetUpskilling.ADO.Net.Repository;
using DotnetUpskilling.ADO.Net.Repository.Service;
using MySql.Data.MySqlClient;

namespace DotnetUpskilling.ADO.Net;

/*
 * pacakage manager dotnet : NuGet
 * package manager java : maven
 * package manager js : npm
 * 
 * ADO.Net : sebuah library .mirip seperti JDBC di java. untuk penghubung antara database ke bahasa pemrograman (C#).
 * Sql Command : class di ADO.Net yang digunakan untuk mengeksekusi operasi query sql
 * mySqlCommand.ExecuteNonQuery() : untuk eksekusi query ddl dan dml
 * mySqlCommand.ExecuteReader() : untuk eksekusi query dql (select)
 * 
 * package :
 * - SQL server : System.Data.SqlClient
 * - Postgre : Npgsql
 * - MySQL : Mysql.Data
 *
 * Connection : diguanakan untuk mengkoneksikan database dengan spesifik driver
 *
 * jangan lupa menutup koneksi database .Close()
 *
 * Data Reader : digunakan untuk read data (select) yang ada didatabase
 */

public class Program
{
    public static void Main(string[] args)
    {
        var connection = DbConfigurationGeneral();
        var connect = ConnectDbSecondWayNewVersion(connection);

        ICustomerRepository customerRepository = new CustomerService(connection);
        Customer customer = new Customer
        {
            Id = 3,
            Name = "irwan",
            PhoneNumber = "08345678"
        };
        // customerRepository.Save(customer);
        // customerRepository.FindById(3);
            customerRepository.FindAll().ForEach(Console.WriteLine);
        
        // ToCreateTable(connect);
        // ToInsertData(connect);
        // ToSelectData(connect);
    }

    private static void ToSelectData(MySqlConnection connect)
    {
        try
        {
            connect.Open();
            const string sql = "select * from m_customer where id=@id";

            var command = new MySqlCommand(sql, connect);

            Console.Write("input the id do you want to search : ");
            var inputId = Console.ReadLine();
            command.Parameters.AddWithValue("@id", inputId);

            var select = command.ExecuteReader();
            if (select.Read())
            {
                Console.WriteLine(
                    $"id : {select.GetInt32(0)}, name : {select.GetString(1)}, number : {select.GetString(2)}, {select.GetString(3)}");
            }
            else
            {
                Console.WriteLine("data is not found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void ToInsertData(MySqlConnection connect)
    {
        try
        {
            connect.Open();
            
            var insert = @"insert into m_customer 
                        values (@id, @name, @phone_number, 'true')";

            Console.Write("input unique id : ");
            var id = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
            Console.Write("input the name : ");
            var name = Console.ReadLine();
            Console.Write("input the phone number : ");
            var phoneNumber = Console.ReadLine();

            var command = new MySqlCommand(insert, connect);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@phone_number", phoneNumber);

            var count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("data successfully inserted");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static void ToCreateTable(MySqlConnection connect)
    {
        try
        {
            var mySqlCommand = new MySqlCommand(@"create table m_customer (
                id int primary key,
                name varchar(100),
                phone_number varchar(100),
                is_active bit
            )", connect);

            // ddl & dml
            mySqlCommand.ExecuteNonQuery();
            Console.WriteLine("table m_customer created successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private static string DbConfigurationGeneral()
    {
        const string localhost = "localhost";
        const string port = "3306";
        const string user =  "root";
        const string password = "";
        const string database = "dotnet_database";
        const string connection = $"server={localhost};port={port};uid={user};pwd={password};database={database}";
        return connection;
    }
    
    private static MySqlConnection ConnectDbFirstWay(string connection)
    {
        // cara pertama
        var connect = new MySqlConnection(connection);
        connect.Open();
        Console.WriteLine("database connected successfully...");
        
        return connect;
    }
    private static void ConnectDbFirstWayCloseWithFinally(string connection)
    {
        MySqlConnection? connect = null;
        try
        {
            // cara pertama
            connect = new MySqlConnection(connection);
            connect.Open();
            Console.WriteLine("database connected successfully...");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        finally
        {
            connect?.Close();
        }
    }
    private static MySqlConnection ConnectDbSecondWayOldVersion(string connection)
    {
        // cara kedua - versi lama | kalau di java mirip seperti try-with-resource (auto-close)
        using (var connect = new MySqlConnection(connection))
        {
            connect.Open();
            Console.WriteLine("database connected successfully...");
            return connect;
        }

    }
    private static MySqlConnection ConnectDbSecondWayNewVersion(string connection)
    {
        // cara kedua - versi baru | kalau di java mirip seperti try-with-resource (auto-close)
        using var connect = new MySqlConnection(connection);
        connect.Open();
        Console.WriteLine("database connected successfully...");
        Debug.Assert(connect != null, nameof(connect) + " != null");
        return connect;
    }
}