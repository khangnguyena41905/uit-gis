import { create } from "zustand";
import { persist } from "zustand/middleware";
import type { IDepartment } from "../interfaces/department.interface";
import type { IEmployee } from "../interfaces/employee.interface";

interface MetadataState {
  departments: IDepartment[];
  employee?: IEmployee;

  setDepartments: (d: IDepartment[]) => void;
  setEmployee: (e: IEmployee) => void;

  reset: () => void;
}

export const useMetadataStore = create<MetadataState>()(
  persist(
    (set) => ({
      departments: [],
      employee: undefined,

      setDepartments: (departments) => set({ departments }),
      setEmployee: (employee) => set({ employee }),

      reset: () =>
        set({
          departments: [],
          employee: undefined,
        }),
    }),
    {
      name: "metadata-storage",
    },
  ),
);
