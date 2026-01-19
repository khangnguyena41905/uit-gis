import { create } from "zustand";

interface LoadingState {
  selectedMonth: Date;
  setSelectedMonth: (val: Date) => void;
}

export const useTimeKeepingStore = create<LoadingState>((set) => ({
  selectedMonth: new Date(),
  setSelectedMonth: (val: Date) => set({ selectedMonth: val }),
}));
