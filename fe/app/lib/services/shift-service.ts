import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IShift } from "../interfaces/shift.interface";
import { BaseService } from "./abstractions/base-service";

export interface IShiftService {
  getPagedShifts(request: IPagedRequest): Promise<IPagedResponse<IShift>>;
  getById(id: number): Promise<IShift>;
  create(
    shift: Omit<IShift, "id" | "createdAt" | "createdBy" | "phanCas">
  ): Promise<IShift>;
  update(id: number, shift: Partial<IShift>): Promise<IShift>;
  delete(id: number): Promise<void>;
}

export class ShiftService extends BaseService implements IShiftService {
  public constructor() {
    super("ca");
  }

  public async getPagedShifts(
    request: IPagedRequest
  ): Promise<IPagedResponse<IShift>> {
    const result = await this.GET<IPagedResponse<IShift>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IShift> {
    const result = await this.GET<IShift>({ url: `${id}` });
    return result;
  }

  public async create(
    shift: Omit<IShift, "id" | "createdAt" | "createdBy" | "phanCas">
  ): Promise<IShift> {
    const result = await this.POST<IShift>({
      url: "",
      body: shift,
    });
    return result;
  }

  public async update(id: number, shift: Partial<IShift>): Promise<IShift> {
    const result = await this.PUT<IShift>({
      url: `${id}`,
      body: shift,
    });
    return result;
  }

  public async delete(id: number): Promise<void> {
    await this.DELETE({ url: `${id}` });
  }
}
