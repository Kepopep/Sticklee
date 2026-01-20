
import { useState } from 'react';

type Props = {
  onClick: (checked: boolean) => void;
};

export function HabitCheackbox({onClick} : Props) {
  const [isChecked, setIsChecked] = useState(false);

  const handleClick = () => {
    const newCheckedState = !isChecked;
    setIsChecked(newCheckedState);
    onClick(newCheckedState);
  };

  return (
    <button
      className={`habit-checkbox ${isChecked ? 'active' : ''}`}
      onClick={handleClick}
      aria-pressed={isChecked}
    >
      {isChecked && <span className="checkmark">✓</span>}
    </button>
  );
}