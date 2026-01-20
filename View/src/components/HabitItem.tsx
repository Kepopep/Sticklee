import { useState } from 'react';
import type { HabitDto, HabitRenameRequest } from '../api/habits/habits.types';
import { HabitCheackbox } from './HabitCheackbox';
import { HabitEdit } from './HabitEdit';

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
        <HabitEdit 
          initialValue = {name}
          onSave={(name) => {
            console.log(name);
            setIsEditing(false);
          }}
          onCancel={() => setIsEditing(false)}/>
      ) : (
        <>
          <HabitCheackbox onClick={(isCliced) => console.log(isCliced)} />
          <span className="habit-icon">🌿</span>
          <span className="habit-name">{habit.name}</span>
          <button className="habit-item-button" onClick={startEdit}>⋯</button>
        </>
      )}
      </li>);
}