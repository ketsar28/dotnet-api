namespace EFUpskilling.Repositories.Implements;

/*
 * DbPersistence class ini masih nge-refer atau ketergantungan sama contextnya. karena kita butuh SaveChanges(), BeginTransaction(), Commit(), Rollback()
 */

public class DbPersistence : IPersistence
{
    private readonly AppCommerceDbContext _commerceDbContext;

    public DbPersistence(AppCommerceDbContext commerceDbContext)
    {
        _commerceDbContext = commerceDbContext;
    }

    public void SaveChanges()
    {
        _commerceDbContext.SaveChanges();
    }

    public void BeginTransaction()
    {
        _commerceDbContext.Database.BeginTransaction();
    }

    public void Commit()
    {
        _commerceDbContext.Database.CommitTransaction();
    }

    public void Rollback()
    {
       _commerceDbContext.Database.RollbackTransaction();
    }
}