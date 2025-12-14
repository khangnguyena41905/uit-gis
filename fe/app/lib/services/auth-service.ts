import type { ILoginData } from "../types/login";
import { BaseService } from "./abstractions/base-service";

export interface IAuthService {
  login(username: string, password: string): Promise<ILoginData>;
}

export class AuthService extends BaseService implements IAuthService {
  public constructor() {
    super("auth");
  }

  public async login(userName: string, password: string) {
    const formData = new FormData();
    formData.append("userName", userName);
    formData.append("password", password);

    const result = await this.POST_FORMDATA<ILoginData>({
      url: "",
      body: formData,
    });
    return result;
  }
}
