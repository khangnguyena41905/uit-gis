import type { IDomainInterface } from "./domain.interface";

export interface ISubarea extends IDomainInterface<number> {
  name: string;
  areaId: number;
  /**
   * polygons described as an array of rings
   * ring = array of points, point = [x, y]
   */
  polygons?: number[][][];
}
