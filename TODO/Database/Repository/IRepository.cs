using Microsoft.EntityFrameworkCore.ChangeTracking;
using TODO.Logic.Interfaces;

namespace TODO.Database.Repository;

public interface IRepository<T> where T : class, IHasId
{
    public ValueTask<T> Create(bool save);
    
    public Task Add(T data, bool save);
    
    public Task<T> Get(Guid id);
    
    public IAsyncEnumerable<T> GetAll();
    
    public Task<T> Update(Guid id, T data, bool save);
    
    public Task Delete(Guid id, bool save);
}