import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IPoint } from "../interfaces/point.interface";
import { BaseService } from "./abstractions/base-service";

export interface IPointService {
  getPagedPoints(request: IPagedRequest): Promise<IPagedResponse<IPoint>>;
  getById(id: number): Promise<IPoint>;
}

export class PointService extends BaseService implements IPointService {
  public constructor() {
    super("points");
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
}
