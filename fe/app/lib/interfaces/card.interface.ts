import type { IDomainInterface } from "./domain.interface";

export interface ICard extends IDomainInterface<string> {
  employeeId: string;
  issuedDate?: string; // ISO date
  isActive: boolean;
  note?: string | null;
}
