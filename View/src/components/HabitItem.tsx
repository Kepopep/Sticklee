import { useState } from 'react';
import type { HabitDto, HabitRenameRequest } from '../api/habits/habits.types';
import { HabitCheackbox } from './HabitCheackbox';
import { HabitEdit } from './HabitEdit';

type Props = {
  habit: HabitDto;
  isEditing?: boolean;
  onEditStart?: () => void;
  onEditEnd?: () => void;
  onRenameSave: (renameRequest: HabitRenameRequest) => void;
  onChecked: (habitId: string, isActive: boolean) => void;
  onDelete: (habitId: string) => void;
};

export function HabitItem({ habit, isEditing = false, onEditStart, onEditEnd, onRenameSave, onChecked, onDelete }: Props & { onDelete: (habitId: string) => void }) {
  const [isUpdating, setIsUpdating] = useState(false);
  const [showMenu, setShowMenu] = useState(false);

  return (
    <li className="habit-item">
      {isUpdating ? (
        <div className='loader'/>
      ) : isEditing ? (
        <HabitEdit
          initialValue = {habit.name}
          onSave={async (name) => {
            console.log(name);

            setIsUpdating(true);
            await onRenameSave({
              id: habit.id,
              name: name,
              frequency: habit.frequency
            });
            setIsUpdating(false);

            if (onEditEnd) {
              onEditEnd();
            }
          }}
          onCancel={() => {
            if (onEditEnd) {
              onEditEnd();
            }
          }}/>
      ) : (
        <>
          <HabitCheackbox
            habitId={habit.id} 
            initialChecked={habit.isChecked} 
            onCheckChange={(checked) => onChecked(habit.id, checked)}/>
          <span className="habit-icon">🌿</span>
          <span className="habit-name">{habit.name}</span>
          <div className="habit-menu-container">
            <button 
              className="habit-item-button" 
              onClick={() => setShowMenu(!showMenu)}
            >
              ⋯
            </button>
            {showMenu && (
              <div className="habit-menu-dropdown">
                <button 
                  className="habit-menu-option habit-edit-option"
                  onClick={() => {
                    if (onEditStart) {
                      onEditStart();
                    }
                    setShowMenu(false);
                  }}
                >
                  Edit
                </button>
                <button 
                  className="habit-menu-option habit-delete-option"
                  onClick={async () => {
                    if (window.confirm(`Are you sure you want to delete "${habit.name}"?`)) {
                      try {
                        setIsUpdating(true);
                        await onDelete(habit.id);
                      } finally {
                        setIsUpdating(false);
                        setShowMenu(false);
                      }
                    }
                  }}
                >
                  Remove
                </button>
              </div>
            )}
          </div>
        </>
      )}
      </li>);
}