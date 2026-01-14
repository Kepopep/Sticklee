using Microsoft.EntityFrameworkCore;
using TODO.Model;

namespace TODO.Database.Repository;

public class HabitLogsRepository(DbContext context) : RepositoryBase<HabitLog>(context, context.Set<HabitLog>())
{
    public override Task<HabitLog> Update(Guid id, HabitLog data, bool save)
    {
        if (data is not HabitLog newData)
        {
            return Task.FromResult(data);
        }
        
        var savedData = Get(id).Result;
        
        savedData.Date = newData.Date;
        savedData.Completed = newData.Completed;

        if (save)
        {
            Context.SaveChanges();
        }
        
        return Task.FromResult(savedData);
    }
}