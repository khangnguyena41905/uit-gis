import type { IDomainInterface } from "./domain.interface";

export interface IPoint extends IDomainInterface<number> {
  x: number;
  y: number;
  name?: string;
}
