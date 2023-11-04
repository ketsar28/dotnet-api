using System.Linq.Expressions;

namespace ClassicShopAPI.Repositories;

/*
 * kalau ada async pasti ada await (dijs), dan dia pake promise. jadi kalau ada promise, itu bisa pake async await.
 *
 * versi asynchronous :
 * - kalau di C# itu pake : Task
 * Task => mirip seperti promise (tidak secara spesifik), jadi dia ini representasi dari asynchrounous operation, dia bisa nge-return value (kalau dia yang generic). jadi kalau ada method yang ada Task<> nya bisa dipasang async await
 *
 *  - TEntity Attach(); => salah satu cara untuk update database, jadi attach ini sebagai penanda, bahwa model yang di attach akan masuk ke EF sebagai Change Trackernya
 *  - Expression<Func<TEntity, bool>> criteria => bisa menggunakan where clause karena dia ini lambda dan kita bisa menggunakan operasi LINQ
 *  - string[] includes => untuk melakukan Join Column
 * 
 */

public interface IRepository<TEntity>
{
    Task<TEntity> SaveAsync(TEntity entity);
    TEntity Attach(TEntity entity);
    Task<TEntity?> FindByIdAsync(Guid id);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria);
    Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes);
    Task<List<TEntity>> FindAllAsync();
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria);
    Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);

}