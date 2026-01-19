import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { ISubarea } from "../interfaces/subarea.interface";
import { BaseService } from "./abstractions/base-service";

export interface ISubareaService {
  getPagedSubareas(request: IPagedRequest): Promise<IPagedResponse<ISubarea>>;
  getById(id: number): Promise<ISubarea>;
}

export class SubareaService extends BaseService implements ISubareaService {
  public constructor() {
    super("phankhu");
  }

  public async getPagedSubareas(
    request: IPagedRequest,
  ): Promise<IPagedResponse<ISubarea>> {
    const result = await this.GET<IPagedResponse<ISubarea>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<ISubarea> {
    const result = await this.GET<ISubarea>({ url: `${id}` });
    return result;
  }
}
