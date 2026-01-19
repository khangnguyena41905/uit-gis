import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IAttendance } from "../interfaces/attendance.interface";
import { BaseService } from "./abstractions/base-service";
import type { IEmployeeMonthlySummary } from "../interfaces/timekeeping.interface";
import { toLocalISOString } from "../utils";

export interface IAttendanceService {
  getPagedAttendances(
    request: IPagedRequest,
  ): Promise<IPagedResponse<IAttendance>>;
  getById(id: number): Promise<IAttendance>;
  /**
   * Get monthly summary of total hours for all employees for the given month/year
   */
  getMonthlySummary(
    request: IPagedRequest & { month: number; year: number },
  ): Promise<IPagedResponse<IEmployeeMonthlySummary>>;
  /**
   * Get raw attendance records for a given employee on a specific date (ISO yyyy-mm-dd)
   */
  getAttendanceHistory(
    employeeId: number,
    fromDate: Date,
    toDate: Date,
  ): Promise<IAttendance[]>;

  checkin(request: {
    theId: number;
    diaDiemId: number;
    gio: string;
  }): Promise<IAttendance>;
}

export class AttendanceService
  extends BaseService
  implements IAttendanceService
{
  public constructor() {
    super("chamcong");
  }
  public async checkin(request: {
    theId: number;
    diaDiemId: number;
    gio: string;
  }): Promise<IAttendance> {
    const result = await this.POST<IAttendance>({
      url: "",
      body: { ...request, isActive: true },
    });
    return result;
  }

  public async getPagedAttendances(
    request: IPagedRequest,
  ): Promise<IPagedResponse<IAttendance>> {
    const result = await this.GET<IPagedResponse<IAttendance>>({
      url: "",
      params: request,
    });
    return result;
  }

  public async getById(id: number): Promise<IAttendance> {
    const result = await this.GET<IAttendance>({ url: `${id}` });
    return result;
  }

  public async getMonthlySummary(
    request: IPagedRequest & { month: number; year: number },
  ): Promise<IPagedResponse<IEmployeeMonthlySummary>> {
    const result = await this.GET<IPagedResponse<IEmployeeMonthlySummary>>({
      url: `tong-hop`,
      params: {
        month: request.month,
        year: request.year,
        pageIndex: request.pageIndex,
        pageSize: request.pageSize,
      },
    });

    // Defensive: if API not ready, return empty
    return result;
  }

  public async getAttendanceHistory(
    employeeId: number,
    fromDate: Date,
    toDate: Date,
  ): Promise<IAttendance[]> {
    try {
      const result = await this.GET<IAttendance[]>({
        url: `history`,
        params: {
          nhanVienId: employeeId,
          fromDate: toLocalISOString(fromDate),
          toDate: toLocalISOString(toDate),
        },
      });
      return result ?? [];
    } catch (error) {
      return [];
    }
  }
}
