import type { IDomainInterface } from "./domain.interface";
import type { ICard } from "./card.interface";
import type { IPoint } from "./point.interface";

export interface IAttendance extends IDomainInterface<number> {
  cardId: string;
  pointId: number;
  location?: string; // textual description of location
  time: string; // ISO datetime
  readonly card?: ICard;
  readonly point?: IPoint;
}
