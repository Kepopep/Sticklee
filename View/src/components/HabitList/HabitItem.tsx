import { useState } from 'react';
import type { HabitDto, HabitRenameRequest } from '../../api/habits/habits.types';

type Props = {
  habit: HabitDto;
  onRenameSave: (renameRequest: HabitRenameRequest) => void;
};

export function HabitItem({ habit, onRenameSave }: Props) {

  const [isEditing, setIsEditing] = useState(false);
  const [isUpdating, setIsUpdating] = useState(false);
  const [isComplete, setIsComplete] = useState(false);
  const [name, setName] = useState(habit.name);

  function startEdit() {
    setIsEditing(true);
  }

  function cancelEdit() {
    setIsEditing(false);
    setName(habit.name);
  }

  async function saveEdit() {
    setIsUpdating(true);
    await onRenameSave({
      id: habit.id,
      name: name,
      frequency: habit.frequency
    });
    setIsUpdating(false);
    setIsEditing(false);
  }

  return (
    <li className="habit-item">
      {isUpdating ? (
        <div className='loader'/>
      ) : isEditing ? (
        <>
          <input
            type="text"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
          <button className="habit-item-button" onClick={saveEdit}>✔️</button>
          <button className="habit-item-button" onClick={cancelEdit}>❌</button>
        </>
      ) : (
        <>
          <span className="habit-icon">🌿</span>
          <span className="habit-name">{habit.name}</span>
          <button className="habit-toggle" aria-pressed="true">
            <span className="checkmark">✓</span>
          </button>
          <button className="habit-item-button" onClick={startEdit}>✅</button>
          <button className="habit-item-button" onClick={startEdit}>⋯</button>
        </>
      )}
      </li>);
}