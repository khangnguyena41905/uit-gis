import type { IDomainInterface } from "./domain.interface";
import type { ICard } from "./card.interface";
import type { IPoint } from "./point.interface";

export interface IAttendance extends IDomainInterface<number> {
  theId: string;
  diaDiemId: number;
  // location?: string; // textual description of location
  gio: string; // ISO datetime
  readonly the?: ICard;
  readonly diem?: IPoint;
}
