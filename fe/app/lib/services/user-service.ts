import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IUser } from "../interfaces/user.interface";
import { BaseService } from "./abstractions/base-service";

export interface IUserService {
  getPagedUser(request: IPagedRequest): Promise<IPagedResponse<IUser>>;
}

export class UserService extends BaseService implements IUserService {
  public constructor() {
    super("users");
  }

  public async getPagedUser(
    request: IPagedRequest
  ): Promise<IPagedResponse<IUser>> {
    const result = await this.GET<IPagedResponse<IUser>>({
      url: "",
      params: request,
    });
    return result;
  }
}
