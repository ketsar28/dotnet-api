using ClassicShopAPI.Entities;
using ClassicShopAPI.Middlewares;
using ClassicShopAPI.Repositories;
using ClassicShopAPI.Repositories.context;
using ClassicShopAPI.Repositories.impl;
using ClassicShopAPI.Services;
using ClassicShopAPI.Services.impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Host.ConfigureLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole(); // supaya dimasukan ke console
});
/*
 * jadi di C# untuk dependency injectionnya harus didaftarkan secara manual di class Program.cs
 *
 * 1. daftarin appDbContext
 * 2. daftarin repository
 * 3. daftarin persistence
 */

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// cara untuk mendaftarkan DbContext (Object) ke dependency/container IoC, supaya dihandle Dependency Injectionnya, jadi bagaimana object itu dibuat apabila object lain itu membutuhkannya

builder.Services.AddDbContext<AppDbContext>
    (opt => opt.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty));

/*
 * life time dari DI ada 3 :
 * 1. singleton : object yang dibuat hanya 1 kali. dan itu akan disimpan selama aplikasi itu berjalan
 * 2. scoped : object ini masa aktif nya selama terdapat request dari si context. contohnya database (linkup : scoped). per-request http client
 * 3. transient : dibuat pada saat setiap kali ada request dari user, contoh ketika ngehit API, jadi 1 request 1 object. per-request juga, namun satu satu jika memang ada 2 request secara berbarengan
 *
 * contoh :
 * - ketika Persistencenya kita gunakan AddSingleton() => itu akan error, kenapa? karena persistencenya ini masih butuh si Context, namun si Context-nya sudah mati terlebih dahulu. (seharusnya ketika repositorynya ditambahkan AddSingleton(), itu juga error)
 * - kalau AddScoped itu lebih aman
 */

/*
 * ada 2 cara penulisan DI :
 * 1. kalau yang pakai typeof() => itu untuk yang datanya generic
 * 2. kalau yang pakai <IRepository, Implements> => untuk bukan yang generic
 */

builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IPersistence, Persistence>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IPurchaseService, PurchaseService>();
builder.Services.AddTransient<HandleExceptionMiddleware>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<HandleExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();