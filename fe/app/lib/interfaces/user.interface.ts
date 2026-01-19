import type { IDomainInterface } from "./domain.interface";

export interface IUser extends IDomainInterface<number> {
  hoTen: string;
  maNV?: string;
  email: string;
  userName: string;
  ngaySinh: string;
  phone: string;
  phongBanId: number;
  isActive: boolean;
}
