using Microsoft.EntityFrameworkCore;
using TODO.Model;

namespace TODO.Database.Repository;

public class HabitRepository(DbContext context) : RepositoryBase<Habit>(context, context.Set<Habit>())
{
    public override Task<Habit> Update(Guid id, Habit data, bool save)
    {
        if (data is not Habit newData)
        {
            return Task.FromResult(data);
        }
        
        var savedData = Get(id).Result;
        
        savedData.Name = newData.Name;
        savedData.User = newData.User;
        savedData.Frequency = newData.Frequency;
        savedData.Logs = newData.Logs;

        if (save)
        {
            Context.SaveChanges();
        }
        
        return Task.FromResult(savedData);
    }
}