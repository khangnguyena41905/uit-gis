import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IEmployee } from "../interfaces/employee.interface";
import { BaseService } from "./abstractions/base-service";

export interface IEmployeeService {
  getPagedEmployees(request: IPagedRequest): Promise<IPagedResponse<IEmployee>>;
  getById(id: string): Promise<IEmployee>;
  create(user: IEmployee): Promise<IEmployee>;
}

export class EmployeeService extends BaseService implements IEmployeeService {
  public constructor() {
    super("nhanvien");
  }

  public async getPagedEmployees(
    request: IPagedRequest
  ): Promise<IPagedResponse<IEmployee>> {
    const result = await this.GET<IPagedResponse<IEmployee>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: string): Promise<IEmployee> {
    const result = await this.GET<IEmployee>({ url: `${id}` });
    return result;
  }

  public async create(user: IEmployee): Promise<IEmployee> {
    const result = await this.POST<IEmployee>({
      url: "",
      body: user,
    });
    return result;
  }
}
