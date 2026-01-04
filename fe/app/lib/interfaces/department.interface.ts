export interface IDepartment {
  id: number;
  name: string;
  positions: IPosition[];
}

export interface IPosition {
  id: number;
  name: string;
  departmentId: number;
  readonly department?: Omit<IDepartment, "positions">;
}
