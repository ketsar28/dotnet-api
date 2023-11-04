

/*
 * ChangeTracker :
 * - Added - penanda saat ingin dilakukan insert entity tersebut untuk siap disimpan ke database
 * - SaveChanges : entity yang sudah siap (Added) untuk disimpan ke database maka harus dimasukan kedalam method SaveChanges supaya diproses
 * - Detached - Entity jejaknya dicopot/pengubah status
 * - Unchange : select (dql)
 * - Modified : update
 * - Deleted : dihapus
 *
 * LINQ :
 * - FirstOrDefault(predicates)
 * predicates : sebuah lambda function
 *
 *
 * note :
 * dia (EF) hanya bisa melakukan perubahan apabila memiliki change tracker
 * - tetap menggunakan context untuk dipassing sebagai dependency injectionnya
 *
 */

using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using EFUpskilling.Repositories.Implements;

public class Program
{
    public static void Main(string[] args)
    {
        // tetap menggunakan context untuk dipassing sebagai dependency injectionnya
        // using AppDbContext context = new();
        
        // InsertData(context);
        // GetCustomerById(context);
        // GetCustomerByName(context);
        // GetAllCustomer(context);
        // UpdateCustomer(context);
        // DeleteCustomer(context);
        
        
        using AppUserDbContext context = new();
        IRepository<User> repository = new Repository<User>(context);

       // InsertUser(repository);
       // GetUserById(repository);
       GetUserByName(repository);
        
       
    }

    public static void GetUserByName(IRepository<User> repository)
    {
        // GET USER BY NAME
        try
        {
            var user = repository.GetBy(user => user.CustomerName.Equals("ketsar"));
            Console.WriteLine($"data : {user.CustomerName}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public static void GetUserById(IRepository<User> repository)
    {
        // GET USER BY ID
        try
        {
            var user = repository.GetById(Guid.Parse("007b1a3b-0111-4aab-b21d-08dbd44df269"));
            Console.WriteLine($"data : {user.CustomerName}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public static void InsertUser(IRepository<User> repository)
    {
        // INSERT DATA
        try
        {
            User user = new()
            {
                CustomerName = "ketsar",
                Address = "Jl. Kesuksesan",
                MobilePhone = "0851xxxx",
                Email = "ketsar@co.id"
            };
            repository.Save(user);
            Console.WriteLine("data entered");
        }
        catch (Exception e)
        {
            Console.WriteLine($"error : {e}");
        }
    }
    
    public static void InsertData(AppDbContext context)
    {
        // CREATE 
        Customer customer = new()
        {
            CustomerName = "nabil",
            Address = "Jl. Keberkahan",
            MobilePhone = "0897xxx",
            Email = "nabil@co.id"
        };
        
        context.Customers.Add(customer); // prepare for save
        var saveChanges = context.SaveChanges(); // save to db
        var isSuccess = saveChanges > 0? "data enterd" : "failed";
        Console.WriteLine(isSuccess);
    }

    public static void GetCustomerById(AppDbContext context)
    {
        // GET BY ID
        var customer = context.Customers.FirstOrDefault(customer => customer.Id.Equals(1)); // state : Unchange
        Console.WriteLine(context.Entry(customer).State); // untuk mendapatkan statenya
        Console.WriteLine($"Id : {customer.Id} - Name : {customer.CustomerName} - Phone : {customer.MobilePhone} - Email : {customer.Email}");
    }

    public static void GetCustomerByName(AppDbContext context)
    {
        // GET BY CUSTOMER NAME
        var customer = context.Customers.FirstOrDefault(customer => customer.CustomerName.ToLower().Equals("NaBiL".ToLower())); // state : Unchange
        Console.WriteLine(context.Entry(customer).State); // untuk mendapatkan statenya
        Console.WriteLine($"Id : {customer.Id} - Name : {customer.CustomerName} - Phone : {customer.MobilePhone} - Email : {customer.Email}");

    }

    public static void GetAllCustomer(AppDbContext context)
    {
        // GET ALL CUSTOMER
        var customers = context.Customers.ToList();
        foreach (var customer in customers)
        {
             Console.WriteLine($"Id : {customer.Id} - Name : {customer.CustomerName} - Phone : {customer.MobilePhone} - Email : {customer.Email}");
        }
    }

    public static void UpdateCustomer(AppDbContext context)
    {
        // UPDATE CUSTOMER
        var customerForUpdate = context.Customers.FirstOrDefault(customer => customer.CustomerName.ToLower().Equals("irwan".ToLower()));
        
        if (customerForUpdate != null)
        {
            customerForUpdate.CustomerName = "Irwan";
            customerForUpdate.Email = "irwan@gmail.com";
            customerForUpdate.Address = "Jl. Kebahagiaan";
            customerForUpdate.MobilePhone = "0851xxx";
        }
        else
        {
            Console.WriteLine("user is not found");
        }
        
        context.Customers.Update(customerForUpdate); // modified
        var saveChanges = context.SaveChanges(); // save to db
        var isSuccess = saveChanges > 0 ? "success updated" : "failed for update";
        Console.WriteLine(isSuccess);
    }

    public static void DeleteCustomer(AppDbContext context)
    {
        // DELETE CUSTOMER
        var isCustomerExists = context.Customers.Any(customer => customer.CustomerName.Equals("nabil", StringComparison.OrdinalIgnoreCase));
        
        if (isCustomerExists)
        {
            var customerForDelete = context.Customers.FirstOrDefault(customer => customer.CustomerName.ToLower().Equals("nabil".ToLower()));
            
            context.Customers.Remove(customerForDelete);
            context.SaveChanges();
            Console.WriteLine("successfully deleted");
        }
        else Console.WriteLine("user is not found");
    }
}