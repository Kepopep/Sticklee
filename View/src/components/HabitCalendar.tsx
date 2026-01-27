import './style/HabitCalendar.css';

// Define types
type HabitLog = {
  id: string;
  habitId: string;
  date: string; // ISO string format
  isCompleted: boolean;
};

type Props = {
  year?: number;
  month?: number; // 0-11 (January is 0, February is 1, etc.)
  habitLogs?: HabitLog[]; // Optional habit logs to show completion status
  selectedDate?: Date | null; // Currently selected date
  onDateSelect?: (date: Date) => void; // Callback when a date is selected
};

export function HabitCalendar({ year = new Date().getFullYear(), month = new Date().getMonth(), habitLogs = [], selectedDate, onDateSelect }: Props) {
  let firstDayOfMonth = new Date(year, month, 1).getDay();
  firstDayOfMonth = firstDayOfMonth === 0 ? 6 : firstDayOfMonth - 1;
  
  const currentDate = new Date();
  const currentDay = currentDate.getDate();
  const currentMonth = currentDate.getMonth();
  const currentYear = currentDate.getFullYear();
  
  const isCurrentMonth = (year === currentYear && month === currentMonth);
  
  const isDaySelected = (day: number) => {
    if (!selectedDate) return false;
    return (
      selectedDate.getDate() === day &&
      selectedDate.getMonth() === month &&
      selectedDate.getFullYear() === year
    );
  };
  
  const daysInMonth = new Date(year, month + 1, 0).getDate();
  const calendarGrid = [];
  
  for (let i = 0; i < firstDayOfMonth; i++) {
    calendarGrid.push(null);
  }
  
  for (let day = 1; day <= daysInMonth; day++) {
    calendarGrid.push(day);
  }
  
  const totalCells = Math.ceil(calendarGrid.length / 7) * 7;
  
  while (calendarGrid.length < totalCells) {
    calendarGrid.push(null);
  }
  
  const weekdays = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
  const getDayCompletionStatus = (day: number) => {
    if (!habitLogs || habitLogs.length === 0) {
      return 'none'; // No logs provided
    }
    
    const dateString = `${year}-${String(month + 1).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
    const dayLogs = habitLogs.filter(log => log.date.startsWith(dateString));
    
    if (dayLogs.length === 0) {
      return 'none'; // No logs for this day
    }
    
    const completedLogs = dayLogs.filter(log => log.isCompleted);
    
    if (completedLogs.length === 0) {
      return 'empty'; // Logs exist but nothing completed
    } else if (completedLogs.length === dayLogs.length) {
      return 'full'; // All habits completed
    } else {
      return 'partial'; // Some habits completed
    }
  };
  
  return (
    <div className="habit-calendar-wrapper">
      <h3 className="habit-calendar-title">{new Date(year, month).toLocaleString('default', { month: 'long', year: 'numeric' })}</h3>
      
      <div className="habit-calendar-grid">
        {/* Weekday headers */}
        {weekdays.map((day, index) => (
          <div key={`header-${index}`} className="habit-calendar-day-header">
            {day}
          </div>
        ))}
        
        {/* Calendar days */}
        {calendarGrid.map((day, index) => {
          const completionStatus = day ? getDayCompletionStatus(day) : null;
          
          return (
            <div
              key={`day-${index}`}
              className={`habit-calendar-day ${
                day
                  ? `habit-calendar-day--valid habit-calendar-day--${completionStatus} ${
                      isCurrentMonth && day === currentDay ? 'habit-calendar-day--today' : ''
                    } ${
                      isDaySelected(day) ? 'habit-calendar-day--selected' : ''
                    }`
                  : 'habit-calendar-day--empty'
              }`}
              onClick={() => {
                if (day && onDateSelect) {
                  const selectedDate = new Date(year, month, day);
                  onDateSelect(selectedDate);
                }
              }}
            >
              {day && (
                <div className="habit-calendar-day-number">
                  {day}
                </div>
              )}
            </div>
          );
        })}
      </div>
    </div>
  );
}