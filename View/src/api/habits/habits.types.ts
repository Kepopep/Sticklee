export type HabitDto = {
    id: string;
    userId: string;
    name: string;
    frequency: number;
}

export type HabitCreateRequest = { 
    name: string;
    frequency: number;
}

export type HabitRenameRequest = {
    id: string;
    name: string;
    frequency: number;
}