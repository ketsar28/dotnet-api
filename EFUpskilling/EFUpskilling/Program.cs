

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
 * Include(lambda => lambda.Attribute) : merupakan query join yang bisa dipakai untuk mendapatkan data dari table/entity referencenya (dengan lambda)
 * Include("Attribute") : merupakan query join yang bisa dipakai untuk mendapatkan data dari table/entity referencenya (dengan nama attribute yang ada di entity/model)
 *
 * kalau nested join, jadi kita ingin mendapatkan data/informasi dari salah satu attribute pada entity/table yang diforeign key kan. karena table/entity saat ini tidak memiliki relasi ke entity/table tersebut. caranya dengan :
 * - .ThenInclude(alias => alias.NamaAttribute)
 * - .Include("NamaAttribute.NamaAttribute")
 *
 * dijava : sudah secara otomatis dijoinkan karena ada yang namanya fetch Eager (Lazy, Eager)
 * di C# (EF) : secara default fetchnya Lazy, jadi harus secara eksplisit dijoinkan
 * 
 * note :
 * dia (EF) hanya bisa melakukan perubahan apabila memiliki change tracker
 * - tetap menggunakan context untuk dipassing sebagai dependency injectionnya
 *
 * file contextnya tidak perlu dipanggil di entry pointnya, karena itu sudah ada di repository filenya. dan SaveChanges() method itu ada di service class. jadi ketika kita ingin melakukan SaveChanges(), tidak perlu memanggil DbContextnya lagi
 *
 */

using EFUpskilling.Entities;
using EFUpskilling.Repositories;
using EFUpskilling.Repositories.Implements;
using EFUpskilling.Services;
using EFUpskilling.Services.Implements;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main(string[] args)
    {

        AppCommerceDbContext context = new();
        IRepository<Purchase> repositoryPurchase = new Repository<Purchase>(context);
        IRepository<Product> repositoryProduct = new Repository<Product>(context);
        IPersistence persistence = new DbPersistence(context);
        IProductService productService = new ProductService(repositoryProduct, persistence);
        IPurchaseService purchaseService = new PurchaseService(repositoryPurchase, persistence, productService);

        Purchase purchase = new()
        {
            TransDate = DateTime.Now,
            UserId = Guid.Parse("623ee329-6397-4c2d-d8f3-08dbd468958e"),
            PurchaseDetails = new List<PurchaseDetail>()
            {
                new() { ProductId = new Guid("52d3fc94-496d-4322-cb7d-08dbd4684ba8"), Qty = 1 },
                new() { ProductId = new Guid("c1ba435c-4e16-4217-cb7b-08dbd4684ba8"), Qty = 2 }
            }
        };

        purchaseService.CreateTransaction(purchase);

    }

    public static void GetPurchaseOnly(AppCommerceDbContext context) 
    {
        var purchaseOnly = context.Purchases
            .FirstOrDefault(purchase => purchase.Id.Equals(Guid.Parse("f986fc6d-e7f4-4d6e-247a-08dbd46ddbd5")));
        if (purchaseOnly != null) Console.WriteLine($"datanya : {purchaseOnly.TransDate}"); 
        // select * from m_purchase
    }

    public static void GetPurchaseWithNestedJoin(AppCommerceDbContext context)
    {
        
        var purchaseWithJoin = context.Purchases
            .Include("User")
            .Include(purchase => purchase.PurchaseDetails)
            .ThenInclude(pd => pd.Product)
            .FirstOrDefault(purchase => purchase.Id.Equals(Guid.Parse("f986fc6d-e7f4-4d6e-247a-08dbd46ddbd5")));
        Console.WriteLine($"datanya : {purchaseWithJoin}");
        /*
         * select * from m_purchase mp
         * join m_user mu on (mp.user_id = mu.id)
         * join trx_purchase_detail tpd on (tpd.purchase_id = mp.id)
         * join m_product mpt on (mpt.id = tpd.product_id);
         */ 
    }
    
    public static void CreatePurchase(AppCommerceDbContext context)
    {
        var transaction = context.Database.BeginTransaction();
        
        try
        {
            Purchase purchase1 = new()
            {
                TransDate = DateTime.Now,
                User = new User
                {
                    CustomerName = "hasyim",
                    Address = "Jl. Pomad",
                    MobilePhone = "0861xxx",
                    Email = "hmulya05@gmail.com"
                },
                // UserId = Guid.Parse("623ee329-6397-4c2d-d8f3-08dbd468958e"),
                PurchaseDetails = new List<PurchaseDetail>()
                {
                    new() { ProductId = new Guid("52d3fc94-496d-4322-cb7d-08dbd4684ba8"), Qty = 1 },
                    new() { ProductId = new Guid("c1ba435c-4e16-4217-cb7b-08dbd4684ba8"), Qty = 2 }
                }
            };
            context.Purchases.Add(purchase1);
            context.SaveChanges();
            
            foreach (var purchaseDetail in purchase1.PurchaseDetails)
            {
                var product = context.Products.FirstOrDefault(product => product.Id.Equals(purchaseDetail.ProductId));

                if (product != null) product.Stock -= purchaseDetail.Qty;
            }

            context.SaveChanges();
            transaction.Commit();
            Console.WriteLine($"purchase with id {purchase1.Id} has created");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            transaction.Rollback();
        }
    }
    
    public static void InsertProducts(IRepository<Product> productRepository)
    {
        try
        {
            Product nextar = new()
            {
                ProductName = "Nextar",
                ProductPrice = 5000,
                Stock = 13
            };
            
            Product nabati = new()
            {
                ProductName = "Nabati",
                ProductPrice = 2500,
                Stock = 9
            };
            
            
            Product coki = new()
            {
                ProductName = "Coki-Coki",
                ProductPrice = 9000,
                Stock = 15
            };
        
            productRepository.Save(nextar);
            Console.WriteLine($"{nextar.ProductName} has been created");
            
            productRepository.Save(nabati);
            Console.WriteLine($"{nabati.ProductName} has been created");
            
            productRepository.Save(coki);
            Console.WriteLine($"{coki.ProductName} has been created");
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    public static void SaveRunVideo8()
    {
        // tetap menggunakan context untuk dipassing sebagai dependency injectionnya
        // using AppDbContext context = new();
        
        // InsertData(context);
        // GetCustomerById(context);
        // GetCustomerByName(context);
        // GetAllCustomer(context);
        // UpdateCustomer(context);
        // DeleteCustomer(context);
    }

    public static void SaveRunVideo9()
    {
        using AppCommerceDbContext context = new();
        IRepository<User> repository = new Repository<User>(context);

        // InsertUser(repository);
        // GetUserById(repository);
        // GetUserByName(repository);
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
            Console.WriteLine($"{user.CustomerName} created");
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