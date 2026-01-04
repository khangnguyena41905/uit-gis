import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IShiftAssignment } from "../interfaces/shift.interface";
import { BaseService } from "./abstractions/base-service";

export interface IShiftService {
  getPagedShifts(
    request: IPagedRequest
  ): Promise<IPagedResponse<IShiftAssignment>>;
  getById(id: number): Promise<IShiftAssignment>;
}

export class ShiftService extends BaseService implements IShiftService {
  public constructor() {
    super("shifts");
  }

  public async getPagedShifts(
    request: IPagedRequest
  ): Promise<IPagedResponse<IShiftAssignment>> {
    const result = await this.GET<IPagedResponse<IShiftAssignment>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IShiftAssignment> {
    const result = await this.GET<IShiftAssignment>({ url: `${id}` });
    return result;
  }
}
