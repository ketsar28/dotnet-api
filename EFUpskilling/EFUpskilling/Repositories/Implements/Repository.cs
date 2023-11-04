namespace EFUpskilling.Repositories.Implements;

/*
 * repository-nya ini untuk dipakai disemua model
 * where TEntity : class : jadi hanya class yang dapat dimasukan kedalam interface ini sebagai representasi dari tipe data generic. selain dari pada class itu tidak boleh
 */

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    // cara seperti untuk melakukan Depencency Injection, tapi bukan DI
    private readonly AppUserDbContext _appUserDbContext;

    public Repository(AppUserDbContext appDbContext)
    {
        _appUserDbContext = appDbContext;
    }

    public TEntity Save(TEntity entity)
    {
        var entry = _appUserDbContext.Set<TEntity>().Add(entity);
        _appUserDbContext.SaveChanges();
        return entry.Entity;
    }

    public TEntity? GetById(Guid id)
    {
        return _appUserDbContext.Set<TEntity>().Find(id);
    }

    public TEntity? GetBy(Func<TEntity, bool> predicate)
    {
        return _appUserDbContext.Set<TEntity>().FirstOrDefault(predicate);
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _appUserDbContext.Set<TEntity>().AsEnumerable();
    }

    public IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate)
    {
        return _appUserDbContext.Set<TEntity>().Where(predicate);
    }

    public void Update(TEntity entity)
    {
       _appUserDbContext.Set<TEntity>().Update(entity);
       _appUserDbContext.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        _appUserDbContext.Set<TEntity>().Remove(entity);
        _appUserDbContext.SaveChanges();
    }
}