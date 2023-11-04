using EFUpskilling.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFUpskilling.Repositories;

/*
 * DbContext : untuk menghubungkan antara database dengan entity yang dibuat. ini mirip seperti JpaRepository<T> di java
 *
 * tetapi kita harus mendafatarkan entity yang kita punya untuk bisa digunakan/diakses tablenya
 *
 * untuk menginstal EF (Core) secara global, gunanya untuk melakukan migrate. migration dari model/entity yang dibuat ke database. nanti secara otomatis akan digenerate codingannya oleh si EF, ini perintah terminalnya :
 * - dotnet tool install --global dotnet-ef
 * - dotnet tool update -g dotnet-ef (apabila sudah ada namum ingin di upgrade versinya)
 *
 * ini dokumentasi EF Core-nya : https://learn.microsoft.com/en-us/ef/core/cli/dotnet
 *
 * apabila EF Core sudah diinstall secara global, ini command untuk melakukan migration :
 * - dotnet ef migrations add NamaBebas
 *
 * untuk dinaikan ke database/dibuatkan database secara otomatis oleh EF-nya, gunakan command :
 * - dotnet ef database update
 * - note :
 *    - apabila tidak bisa menggunakan command dotnet ef, jalankan di terminal cmd sebagai administrator, lalu arahkan ke project yang sedang dibuat. jalankan ulang perintah dotnet efnya
 *
 * note :
 * - di mysql tidak ada 'TrustServerCertificate=True'
 * - penggantinya bisa menggunakan sslmode=value
 * - tetapi sebenarnya itu tidak perlu kalau di-mysql
 * - kalau menggunakan sql server wajib menambahkan ini 'TrustServerCertificate=True'
 */

public class AppDbContext : DbContext
{
    public DbSet<Customer> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306;uid=root;pwd='';database=dotnet_ef_core");
    }
}