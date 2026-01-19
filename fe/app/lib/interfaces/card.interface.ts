import type { IDomainInterface } from "./domain.interface";

export interface ICard extends IDomainInterface<number> {
  maThe: string;
  nhanVienId: number;
  ngayCap?: string; // ISO date (yyyy-MM-dd)
  isActive: boolean;
}
