import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IEmployee } from "../interfaces/employee.interface";
import { BaseService } from "./abstractions/base-service";

export interface IEmployeeService {
  getPagedEmployees(request: IPagedRequest): Promise<IPagedResponse<IEmployee>>;
  getById(id: string): Promise<IEmployee>;
}

export class EmployeeService extends BaseService implements IEmployeeService {
  public constructor() {
    super("users");
  }

  public async getPagedEmployees(
    request: IPagedRequest
  ): Promise<IPagedResponse<IEmployee>> {
    debugger;
    const result = await this.GET<IPagedResponse<IEmployee>>({
      url: "",
      params: request,
    });
    debugger;
    return result;
  }

  public async getById(id: string): Promise<IEmployee> {
    const result = await this.GET<IEmployee>({ url: `${id}` });
    return result;
  }
}
