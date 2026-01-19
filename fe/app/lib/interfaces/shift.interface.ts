import type { IDomainInterface } from "./domain.interface";

export interface IShift extends IDomainInterface<number> {
  maCa: string;
  tenCa: string;
  gioBD: string; // HH:MM:SS
  gioKT: string; // HH:MM:SS
  isActive: boolean;
  phanCas: IAssignment[];
  createdBy: string;
  createdAt: string; // ISO datetime
}

export interface IAssignment extends IDomainInterface<number> {
  caId: number;
  nhanVienId: number;
  diaDiemId: number;
  ngayBD: string; // YYYY-MM-DD
  ngayKT?: string; // YYYY-MM-DD, optional
  isActive: boolean;
  createdBy: string;
  createdAt: string; // ISO datetime
}
