using ClassicShopAPI.Repositories.context;

namespace ClassicShopAPI.Repositories.impl;

/*
 * class ini digunakan apabila kita tidak ingin memanggil app db context (context file-nya) di service. jadi kita bisa pakai class Persistence ini sebagai penghubungnya
 * 
 */

public class Persistence : IPersistence
{

    private readonly AppDbContext _appDbContext;

    public Persistence(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task SaveChangesAsync()
    {
       await _appDbContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        await _appDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        await _appDbContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransactionAsync()
    {
        await _appDbContext.Database.RollbackTransactionAsync();
    }
}