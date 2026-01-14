using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using TODO.Logic.Fabric;
using TODO.Logic.Interfaces;

namespace TODO.Database.Repository;

public abstract class RepositoryBase<T> : IRepository<T> where T : class, IHasId, new()
{
    protected readonly DbContext Context;
    protected readonly DbSet<T> DbSet;

    protected RepositoryBase(DbContext context, DbSet<T> dbSet)
    {
        Context = context;
        DbSet = dbSet;
    }

    public async ValueTask<T> Create(bool save)
    {
        var item = new T() { Id = new Guid() };
        var entry = await DbSet.AddAsync(item);

        if (save)
        {
            await Context.SaveChangesAsync();
        }
        
        return entry.Entity;
    }

    public Task Add(T item, bool save = false)
    {
        return save
            ? Task.Run(() =>  {
                DbSet.AddAsync(item);
                Context.SaveChangesAsync();
            }) : DbSet.AddAsync(item).AsTask();
    }

    public Task<T> Get(Guid id)
    {
        return (DbSet.FirstOrDefaultAsync(x => x.Id == id) as Task<T>)!;
    }

    public IAsyncEnumerable<T> GetAll()
    {
        return DbSet.AsAsyncEnumerable();
    }

    public abstract Task<T> Update(Guid id, T data, bool save);
    
    public virtual Task Delete(Guid id, bool save = false)
    {
        var item = Get(id).Result;
        
        return save
            ? Task.Run(() =>  {
                DbSet.Remove(item);
                Context.SaveChangesAsync();
            }) : Task.FromResult(DbSet.Remove(item));
    }
}