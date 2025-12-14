import type { IDepartment, IPosition } from "../departments/department.model";

export interface IEmployee {
  id: number;
  code: string;
  name: string;
  userName: string;
  email: string;
  phone: string;
  isActive: boolean;
  deparmentId?: IDepartment["id"];
  readonly department?: Pick<IPosition, "id" | "name">;
  positionId?: IPosition["id"];
  readonly position?: Pick<IPosition, "id" | "name">;
}
