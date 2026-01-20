import { useState } from 'react';
import type { KeyboardEvent } from 'react';
import './style/HabitEdit.css';

type Props = {
  initialValue?: string;
  onSave: (value: string) => void;
  onCancel: () => void;
};

export function HabitEdit({ initialValue = '', onSave, onCancel }: Props) {
  const [value, setValue] = useState(initialValue);

  const handleKeyDown = (e: KeyboardEvent<HTMLInputElement>) => {
    if (e.key === 'Enter') {
      onSave(value);
    } else if (e.key === 'Escape') {
      onCancel();
    }
  };

  return (
    <div className="habit-edit-container">
      <input
        type="text"
        className="habit-edit-input"
        value={value}
        onChange={(e) => setValue(e.target.value)}
        onKeyDown={handleKeyDown}
        placeholder="new habit name"
        autoFocus
      />
      <button className="habit-edit-check-btn" onClick={() => onSave(value)}>
        ✔️
      </button>
      <button className="habit-edit-cancel-btn" onClick={onCancel}>
        ❌
      </button>
    </div>
  );
}