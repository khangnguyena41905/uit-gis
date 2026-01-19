import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IPoint } from "../interfaces/point.interface";
import { BaseService } from "./abstractions/base-service";

export interface IPointService {
  getPagedPoints(request: IPagedRequest): Promise<IPagedResponse<IPoint>>;
  getById(id: number): Promise<IPoint>;
  create(
    point: Omit<
      IPoint,
      | "id"
      | "createdAt"
      | "createdBy"
      | "diem_PhanKhus"
      | "phanCas"
      | "chamCongs"
    >
  ): Promise<IPoint>;
  update(id: number, point: Partial<IPoint>): Promise<IPoint>;
  delete(id: number): Promise<void>;
}

export class PointService extends BaseService implements IPointService {
  public constructor() {
    super("diem");
  }

  public async getPagedPoints(
    request: IPagedRequest
  ): Promise<IPagedResponse<IPoint>> {
    const result = await this.GET<IPagedResponse<IPoint>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IPoint> {
    const result = await this.GET<IPoint>({ url: `${id}` });
    return result;
  }

  public async create(
    point: Omit<
      IPoint,
      | "id"
      | "createdAt"
      | "createdBy"
      | "diem_PhanKhus"
      | "phanCas"
      | "chamCongs"
    >
  ): Promise<IPoint> {
    const result = await this.POST<IPoint>({
      url: "",
      body: point,
    });
    return result;
  }

  public async update(id: number, point: Partial<IPoint>): Promise<IPoint> {
    const result = await this.PUT<IPoint>({
      url: `${id}`,
      body: point,
    });
    return result;
  }

  public async delete(id: number): Promise<void> {
    await this.DELETE({ url: `${id}` });
  }
}
