import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { ISubarea } from "../interfaces/subarea.interface";
import { BaseService } from "./abstractions/base-service";
import { mockSubareas } from "../mock/mock-data";

const USE_MOCKS =
  (import.meta.env.VITE_USE_MOCKS ?? "false") === "true" ||
  import.meta.env.DEV === true;

export interface ISubareaService {
  getPagedSubareas(request: IPagedRequest): Promise<IPagedResponse<ISubarea>>;
  getById(id: number): Promise<ISubarea>;
}

export class SubareaService extends BaseService implements ISubareaService {
  public constructor() {
    super("subareas");
  }

  public async getPagedSubareas(
    request: IPagedRequest
  ): Promise<IPagedResponse<ISubarea>> {
    if (USE_MOCKS) {
      const items = mockSubareas();
      return {
        items,
        totalCount: items.length,
        pageIndex: request.pageIndex,
        pageSize: request.pageSize,
      } as IPagedResponse<ISubarea>;
    }

    const result = await this.GET<IPagedResponse<ISubarea>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<ISubarea> {
    if (USE_MOCKS) {
      const found = mockSubareas().find((s) => s.id === id);
      if (found) return found as ISubarea;
    }

    const result = await this.GET<ISubarea>({ url: `${id}` });
    return result;
  }
}
