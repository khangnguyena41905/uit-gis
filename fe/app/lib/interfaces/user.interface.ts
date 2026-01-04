import type { IPosition } from "./department.interface";
import type { IDomainInterface } from "./domain.interface";

export interface IUser extends IDomainInterface<number> {
  name: string;
  code?: string;
  email: string;
  userName: string;
  phone: string;
  positionId: string;
  readonly position?: Pick<IPosition, "id" | "name" | "department">;
  isActive: boolean;
}
