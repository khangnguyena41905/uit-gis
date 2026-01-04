import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IArea } from "../interfaces/area.interface";
import { BaseService } from "./abstractions/base-service";

export interface IAreaService {
  getPagedAreas(request: IPagedRequest): Promise<IPagedResponse<IArea>>;
  getById(id: number): Promise<IArea>;
}

export class AreaService extends BaseService implements IAreaService {
  public constructor() {
    super("areas");
  }

  public async getPagedAreas(
    request: IPagedRequest
  ): Promise<IPagedResponse<IArea>> {
    const result = await this.GET<IPagedResponse<IArea>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IArea> {
    const result = await this.GET<IArea>({ url: `${id}` });
    return result;
  }
}
