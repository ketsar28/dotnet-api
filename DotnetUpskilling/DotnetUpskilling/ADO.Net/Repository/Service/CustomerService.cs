using DotnetUpskilling.ADO.Net.Entity;
using MySql.Data.MySqlClient;

namespace DotnetUpskilling.ADO.Net.Repository.Service;

public class CustomerService : ICustomerRepository
{
    private readonly MySqlConnection? _mySqlConnection;

    public CustomerService(string? mySqlConnection)
    {
        _mySqlConnection = new MySqlConnection(mySqlConnection);
    }

    public void GeneratedTable()
    {
        try
        {
            _mySqlConnection.Open();
            
            var command = new MySqlCommand(@"create table m_customer (
                id int primary key,
                name varchar(100),
                phone_number varchar(100),
                is_active bit
            )", _mySqlConnection);

            // ddl & dml
            command.ExecuteNonQuery();
            Console.WriteLine("table m_customer created successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void Save(Customer customer)
    {
        try
        {
            _mySqlConnection.Open();
            
            var insert = @"insert into m_customer 
                        values (@id, @name, @phone_number, 'true')";

            var command = new MySqlCommand(insert, _mySqlConnection);
            command.Parameters.AddWithValue("@id", customer.Id);
            command.Parameters.AddWithValue("@name", customer.Name);
            command.Parameters.AddWithValue("@phone_number", customer.PhoneNumber);

            var count = command.ExecuteNonQuery();
            if (count > 0)
            {
                Console.WriteLine("data entered successfully");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public Customer? FindById(int customerId)
    {
        Customer? foundCustomer = null;
        try
        {
            _mySqlConnection.Open();
            const string sql = "select * from m_customer where id=@id";

            var command = new MySqlCommand(sql, _mySqlConnection);

            command.Parameters.AddWithValue("@id", customerId);
            
            var select = command.ExecuteReader();
            if (select.Read())
            {
                foundCustomer = new Customer
                {
                    Id = select.GetInt32(0),
                    Name = select.GetString(1),
                    PhoneNumber = select.GetString(2),
                    IsActive = select.GetBoolean(3)
                };
                
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

        return foundCustomer;
    }

    public List<Customer> FindAll()
    {
        var customers = new List<Customer>();
        try
        {
            _mySqlConnection.Open();
            const string sql = "select * from m_customer";
            var command = new MySqlCommand(sql, _mySqlConnection);
            var selectAll = command.ExecuteReader();

            while (selectAll.Read())
            {
                Customer customer = new Customer
                {
                    Id = Convert.ToInt32(selectAll["id"]),
                    Name = selectAll["name"].ToString(),
                    PhoneNumber = selectAll["phone_number"].ToString(),
                    IsActive = Convert.ToBoolean(selectAll["is_active"])
                };
                customers.Add(customer);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return customers;
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }

    public void DeleteById(int customerId)
    {
        throw new NotImplementedException();
    }
}