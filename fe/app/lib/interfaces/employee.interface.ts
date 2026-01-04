import type { IDomainInterface } from "./domain.interface";
import type { IDepartment } from "./department.interface";

export interface IEmployee extends IDomainInterface<string> {
  code?: string;
  fullName: string;
  dob?: string; // ISO date string
  phone?: string;
  email?: string;
  userName?: string;
  password?: string;
  departmentId?: number;
  readonly department?: Omit<IDepartment, "positions">;
  isActive?: boolean;
}
