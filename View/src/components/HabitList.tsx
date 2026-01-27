import { useState } from 'react';
import type { HabitDto, HabitRenameRequest } from "../api/habits/habits.types";
import { HabitItem } from "./HabitItem";

type Props = {
    habits: HabitDto[];
    selectedDate?: Date | null;
    onAddClick: () => void;
    onRenameSave: (renameRequest: HabitRenameRequest) => void;
    onChecked: (habitId: string, isActive: boolean) => void;
    onDelete: (habitId: string) => void;
}

export function HabitList({ habits, selectedDate, onAddClick, onRenameSave, onChecked, onDelete} : Props) {
    const [editingHabitId, setEditingHabitId] = useState<string | null>(null);

    // Format date for display
    const formatDate = (date: Date | null | undefined) => {
        if (!date) {
            // If no date is selected, show today's date
            const today = new Date();
            return `${today.getDate()}.${today.getMonth() + 1}.${today.getFullYear()}`;
        }
        return `${date.getDate()}.${date.getMonth() + 1}.${date.getFullYear()}`;
    };

    return (
        <div className="habit-list-wrapper">
            <h3 className="habit-list-title">Habits for {formatDate(selectedDate)}</h3>

            <div className="habit-card">
                <ul className="habit-list">
                {habits.map((habit) => (
                    <HabitItem
                        key={habit.id}
                        habit={habit}
                        isEditing={editingHabitId === habit.id}
                        onEditStart={() => setEditingHabitId(habit.id)}
                        onEditEnd={() => setEditingHabitId(null)}
                        onRenameSave={onRenameSave}
                        onChecked={onChecked}
                        onDelete={onDelete}
                    />
                ))}
                </ul>

                <button className="habit-add-btn" onClick={onAddClick}>
                    <span className="habit-add-icon">+</span>
                    Add Habit
                </button>
            </div>
        </div>
    );
}
