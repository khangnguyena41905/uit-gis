import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IDepartment } from "../interfaces/department.interface";
import { BaseService } from "./abstractions/base-service";

export interface IDepartmentService {
  getPagedDepartments(
    request: IPagedRequest
  ): Promise<IPagedResponse<IDepartment>>;
  getById(id: number): Promise<IDepartment>;
}

export class DepartmentService
  extends BaseService
  implements IDepartmentService
{
  public constructor() {
    super("departments");
  }

  public async getPagedDepartments(
    request: IPagedRequest
  ): Promise<IPagedResponse<IDepartment>> {
    const result = await this.GET<IPagedResponse<IDepartment>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IDepartment> {
    const result = await this.GET<IDepartment>({ url: `${id}` });
    return result;
  }
}
