import type { IDomainInterface } from "./domain.interface";
import type { IDepartment } from "./department.interface";
import type { ICard } from "./card.interface";
import type { IAssignment } from "./shift.interface";

export interface IEmployee extends IDomainInterface<number> {
  maNV?: string;
  hoTen: string;
  ngaySinh?: string; // ISO date string
  sdt?: string;
  email?: string;
  userName?: string;
  password?: string;
  roleId: number;
  phongBanId?: number;
  readonly department?: Omit<IDepartment, "positions">;
  isActive?: boolean;
  theTus?: ICard[];
  phanCas?: IAssignment[];
}
