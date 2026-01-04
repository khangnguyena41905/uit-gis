import type { IDomainInterface } from "./domain.interface";

export interface IArea extends IDomainInterface<number> {
  name: string;
}
