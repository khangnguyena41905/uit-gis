import type { IDomainInterface } from "./domain.interface";
import type { IPointSubarea } from "./point-subarea.interface";

export interface ISubarea extends IDomainInterface<number> {
  maPhanKhu: string;
  tenPhanKhu: string;
  khuVucId: number;
  isActive: boolean;
  diem_PhanKhus: IPointSubarea[];
}
