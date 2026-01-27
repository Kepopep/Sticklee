import "../components/style/HabitList.css";
import "../components/style/HabitItem.css";
import "../components/style/HabitCheackbox.css"
import "../components/style/HabitCalendar.css"

import { useEffect, useState } from "react";
import { checkHabit, createHabit, deleteHabit, getHabits, updateHabitName} from "../api/habits/habits.api";
import { HabitList } from "../components/HabitList";
import { HabitCalendar } from "../components/HabitCalendar";

import type { HabitDto, HabitRenameRequest, HabitCheckRequest } from "../api/habits/habits.types";

// Define HabitLog type based on API usage
type HabitLog = {
  id: string;
  habitId: string;
  date: string; // ISO string format
  isCompleted: boolean;
};

export function HabitPage() {
    const [habits, setHabits] = useState<HabitDto[]>([]);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [error, setError] = useState<string | null>(null);
    const [selectedDate, setSelectedDate] = useState<Date>(new Date());

    useEffect(() => {
        loadHabits(selectedDate);
    }, [selectedDate]);

    const [habitLogs, setHabitLogs] = useState<HabitLog[]>([]);

    async function loadHabits(date: Date) {
        try {
            console.log("page" + date);
            const data = await getHabits(date);
            setHabits(data);
            
            // Load habit logs for the current month after loading habits
            await loadHabitLogsForCurrentMonth(data);
        } catch {
            setError("Failed to fetch habits");
        } finally {
            setIsLoading(false);
        }
    }

    // Function to load habit logs for the current month
    async function loadHabitLogsForCurrentMonth(habitsData: HabitDto[]) {
        try {
            // For now, we'll simulate loading habit logs for the current month
            // In a real implementation, you'd need an API endpoint to fetch logs for a date range
            const currentYear = new Date().getFullYear();
            const currentMonth = new Date().getMonth();
            
            // Calculate start and end date for the month
            const startDate = new Date(currentYear, currentMonth, 1);
            const endDate = new Date(currentYear, currentMonth + 1, 0); // Last day of month
            
            // This is a placeholder implementation - in reality, you'd need an API call
            // to fetch habit logs for the specified date range
            const logs: HabitLog[] = [];
            
            // Simulate some logs for demonstration purposes
            // In a real implementation, you would fetch this data from the backend
            habitsData.forEach(habit => {
                // Generate some sample logs for different days in the month
                for (let day = 1; day <= 15; day += 3) { // Every 3rd day for demo
                    const dateStr = `${currentYear}-${String(currentMonth + 1).padStart(2, '0')}-${String(day).padStart(2, '0')}`;
                    
                    // Randomly decide if the habit was completed
                    const isCompleted = Math.random() > 0.3; // 70% chance of completion for demo
                    
                    logs.push({
                        id: `${habit.id}-${dateStr}`,
                        habitId: habit.id,
                        date: dateStr,
                        isCompleted
                    });
                }
            });
            
            setHabitLogs(logs);
        } catch (err) {
            console.error('Failed to load habit logs:', err);
            // Continue without logs rather than showing an error
        }
    }
    
    async function addHabit() {
        const data = await createHabit({ 
            name: "New Habit",
            frequency: 0
        });
    
        await loadHabits(selectedDate);
    }

    async function updateName(renameRequest : HabitRenameRequest) {
        await updateHabitName({ 
            id: renameRequest.id,
            name: renameRequest.name,
            frequency: renameRequest.frequency
        });
        
        await loadHabits(selectedDate);
    }

    const habitChecked = async (habitId: string, isActive: boolean) => {
        try {
            await checkHabit({
                id: habitId,
                isChecked: isActive,
                date: selectedDate ?? new Date()
            });

            await loadHabits(selectedDate);
        } catch (error) {
            console.error('Failed to update habit check status:', error);
            // Optionally refresh the habits list to revert any optimistic UI updates
        }
    };

    const handleDelete = async (habitId: string) => {
        try {
            await deleteHabit(habitId);
            await loadHabits(selectedDate); // Refresh the list after deletion
        } catch (error) {
            console.error('Failed to delete habit:', error);
            // Optionally show an error message to the user
        }
    };

    if(isLoading)
        return <div>Loading...</div>

    if(error)
        return <div>{error}</div>

    return (
        <div className="habit-page-container">
            <HabitCalendar
                habitLogs={habitLogs}
                selectedDate={selectedDate}
                onDateSelect={setSelectedDate}
            />
            <HabitList
                habits={habits}
                selectedDate={selectedDate}
                onAddClick={addHabit}
                onRenameSave={updateName}
                onChecked={habitChecked}
                onDelete={handleDelete}
            />
        </div>
    );
}