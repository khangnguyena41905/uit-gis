import type { IDomainInterface } from "./domain.interface";

export interface IShiftAssignment extends IDomainInterface<number> {
  employeeId: string;
  pointId: number;
  startTime: string; // ISO datetime
  endTime: string; // ISO datetime
}
