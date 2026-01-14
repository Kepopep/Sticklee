using Microsoft.EntityFrameworkCore;
using TODO.Model;

namespace TODO.Database;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> builder) : DbContext(builder)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Habit> Habits { get; set; }
    public DbSet<HabitLog> HabitLogs { get; set; }
}