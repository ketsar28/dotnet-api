using System.Linq.Expressions;
using ClassicShopAPI.Repositories.context;
using Microsoft.EntityFrameworkCore;

namespace ClassicShopAPI.Repositories.impl;

/*
 *  Repository<TEntity> akan dipassing ke IRepository<TEntity>
 *  Dependency Injection (DI) di C#/.NET menggunakan keyword 'private dan readonly' dan dibuat constructor manual. kenapa perlu dibuat constructor, supaya nanti diatur secara otomatis oleh IoC (Inversion of Control) milik si .NET
 *
 * AsQueryable() => dia yang punya Include, diubah dulu menjadi queryable supaya dapet include/dapet query join milik LINQ
 *
 *  method chaining => query.Include().Include().FirstOrDefaultAsync();
 *
 * Attach => ini fungsinya untuk entity yang punya id, akan diset/ke-track oleh entity framework (EF) jadi Unchange statenya. jadi masih bisa di update walaupun tidak di GetById terlebih dahulu. yang penting punya primary key. tapi kalau primary keynya belum ada maka akan Added state, akan ditambahkan
 */

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext _context;

    public Repository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TEntity> SaveAsync(TEntity entity)
    {
        var entry = await _context.Set<TEntity>().AddAsync(entity);
        return entry.Entity;
    }

    public TEntity Attach(TEntity entity)
    {
        var entry = _context.Set<TEntity>().Attach(entity);
        return entry.Entity;
    }

    public async Task<TEntity?> FindByIdAsync(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(criteria);
    }

    public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
    {
        var query = _context.Set<TEntity>().AsQueryable();

        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        

        return await query.FirstOrDefaultAsync(criteria);
    }

    public async Task<List<TEntity>> FindAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria)
    {
        return await _context.Set<TEntity>().Where(criteria).ToListAsync();
    }

    public async Task<List<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> criteria, string[] includes)
    {
        var query = _context.Set<TEntity>().Where(criteria).AsQueryable();

        query = includes.Aggregate(query, (current, include) => current.Include(include));

        return await _context.Set<TEntity>().Where(criteria).ToListAsync();
    }

    public TEntity Update(TEntity entity)
    {
        Attach(entity);
        _context.Set<TEntity>().Update(entity);
        return entity;
    }

    public void Delete(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
}