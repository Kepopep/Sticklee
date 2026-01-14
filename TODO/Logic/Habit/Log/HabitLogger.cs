using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODO.Database.Repository;
using TODO.Logic.Fabric;
using TODO.Model;
using TODO.Model.DTO;


public class HabitLogger
{
    private IRepository<HabitLog> _logRepository;
    private readonly IRepository<Habit> _habitRepository;

    public HabitLogger(IRepository<HabitLog> logRepository, IRepository<Habit> habitRepository)
    {
        _logRepository = logRepository;
        _habitRepository = habitRepository;
    }
    
    public async Task<HabitLog> CreateLog(HabitLogCreateData data)
    {
        var logOwner = _habitRepository.Get(data.HabitId).Result;
        var log = HasIdFabric<HabitLog>.GetObject();

        if (logOwner == null)
        {
            return null!;
        }
        
        log.Date = data.Date == default ? DateTime.Now : data.Date;
        log.Completed = data.Completed;
        log.Habit = logOwner;
        
        logOwner.Logs.Add(log);

        await _logRepository.Add(log, false);
        await _habitRepository.Update(logOwner.Id, logOwner, true);

        return log;
    }

    public async Task DeleteLog(Guid id)
    {  
        var log = _logRepository.Get(id).Result;

        if (log == null)
        {
            return;
        }
        
        var logOwner = log.Habit;

        logOwner.Logs.Remove(log);

        await _logRepository.Delete(log.Id, true);
    }

    public async Task<HabitLog> UpdateLog(Guid id, HabitLogUpdate data)
    {
        var log = _logRepository.Get(id).Result;

        if (log == null)
        {
            return null;
        }
        
        log.Date = data.Date == default ? log.Date : data.Date;
        log.Completed = data.Completed;
        
        _logRepository.Update(id, log, true);
        
        return log;
    }
}