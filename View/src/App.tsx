import { useState } from 'react'
import { HabitPage } from './pages/HabitPage.tsx'
import './App.css'

function App() {
  const [count, setCount] = useState(0)

  return <HabitPage />;  
}

export default App
