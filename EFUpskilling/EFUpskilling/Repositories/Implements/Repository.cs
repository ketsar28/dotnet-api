namespace EFUpskilling.Repositories.Implements;

/*
 * repository-nya ini untuk dipakai disemua model
 * where TEntity : class : jadi hanya class yang dapat dimasukan kedalam interface ini sebagai representasi dari tipe data generic. selain dari pada class itu tidak boleh
 */

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    // cara seperti untuk melakukan Depencency Injection, tapi bukan DI
    private readonly AppCommerceDbContext _appCommerceDbContext;

    public Repository(AppCommerceDbContext appDbContext)
    {
        _appCommerceDbContext = appDbContext;
    }

    public TEntity Save(TEntity entity)
    {
        var entry = _appCommerceDbContext.Set<TEntity>().Add(entity);

        return entry.Entity;
    }

    public TEntity? GetById(Guid id)
    {
        return _appCommerceDbContext.Set<TEntity>().Find(id);
    }

    public TEntity? GetBy(Func<TEntity, bool> predicate)
    {
        return _appCommerceDbContext.Set<TEntity>().FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _appCommerceDbContext.Set<TEntity>().AsEnumerable();
    }

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
    {
        return _appCommerceDbContext.Set<TEntity>().Where(predicate);
    }

    public void Update(TEntity entity)
    {
       _appCommerceDbContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _appCommerceDbContext.Set<TEntity>().Remove(entity);

    }
}