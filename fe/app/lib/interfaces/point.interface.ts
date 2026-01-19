import type { IDomainInterface } from "./domain.interface";
import type { IAssignment } from "./shift.interface";
import type { IAttendance } from "./attendance.interface";
import type { ISubarea } from "./subarea.interface";

export interface IPoint extends IDomainInterface<number> {
  maDiaDiem: string;
  tenDiaDiem: string;
  x: number;
  y: number;
  isActive: boolean;
  diem_PhanKhus: ISubarea[];
  phanCas: IAssignment[];
  chamCongs: IAttendance[];
  createdBy: string;
  createdAt: string; // ISO datetime
}
