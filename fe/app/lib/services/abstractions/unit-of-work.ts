import { AuthService, type IAuthService } from "../auth-service";

interface IUnitOfWork {
  authService: IAuthService;
}

class UnitOfWork implements IUnitOfWork {
  private static unitOfWork: IUnitOfWork;
  public static getUnitOfWork(): IUnitOfWork {
    return (UnitOfWork.unitOfWork = UnitOfWork.unitOfWork ?? new UnitOfWork());
  }

  private _authService: IAuthService = new AuthService();
  public get authService(): IAuthService {
    return (this._authService = this._authService ?? new AuthService());
  }
}

export const unitOfWork = UnitOfWork.getUnitOfWork();
