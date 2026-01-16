namespace TODO.Application.HabitLog.GetById;

public interface IGetHabitLogByIdService
{
    Task<GetHabitLogByIdDto> ExecuteAsync(Guid id);
}