namespace EFUpskilling.Repositories;

/*
 * Guid : Guid ini seperti UUID (string random yang sifatnya unique).  data untuk mencari data berdasarkan id
 * Func<T, bool> : sebuah function/method lambda 
 */

public interface IRepository<TEntity>
{
    TEntity Save(TEntity entity);
    TEntity? GetById(Guid id);
    TEntity? GetBy(Func<TEntity, bool> predicate);
    IEnumerable<TEntity> GetAll();
    IEnumerable<TEntity> GetAll(Func<TEntity, bool> predicate);
    void Update(TEntity entity);
    void Delete(TEntity entity);

}