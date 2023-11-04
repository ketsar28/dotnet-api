using EFUpskilling.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFUpskilling.Repositories;
/*
 * apabila sudah ada context sebelumnya, dan ingin melakukan migrate ulang untuk context lainnya kita bisa masukan spesific context class nya, dengan command :
 * dotnet ef migrations add SecondCreate --context AppUserDbContext
 * note : AppUserDbContext, ini nama class contextnya
 *
 * ketika ingin dibuatkan tablenya menggunakan :
 * 'dotnet ef database update' itu menjadi 'dotnet ef database update -c NamaContextClassnya'
 */
public class AppUserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySQL("server=localhost;port=3306;uid=root;pwd='';database=dotnet_ef_core");
    }
}