using Microsoft.EntityFrameworkCore;
using TODO.Model;

namespace TODO.Database.Repository;

public class UserRepository(DbContext context) : RepositoryBase<User>(context, context.Set<User>())
{
    public override Task<User> Update(Guid id, User data, bool save)
    {
        if (data is not User newData)
        {
            return Task.FromResult(data);
        }
        
        var savedData = Get(id).Result;
        
        savedData.Name = newData.Name;

        if (save)
        {
            Context.SaveChanges();
        }
        
        return Task.FromResult(savedData);
    }
}