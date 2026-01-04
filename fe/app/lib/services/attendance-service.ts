import type {
  IPagedRequest,
  IPagedResponse,
} from "../interfaces/paged.interface";
import type { IAttendance } from "../interfaces/attendance.interface";
import { BaseService } from "./abstractions/base-service";
import type { IEmployeeMonthlySummary } from "../interfaces/timekeeping.interface";
import {
  mockMonthlySummary,
  mockAttendancesForEmployeeOnDate,
} from "../mock/mock-data";

const USE_MOCKS =
  (import.meta.env.VITE_USE_MOCKS ?? "false") === "true" ||
  import.meta.env.DEV === true;

export interface IAttendanceService {
  getPagedAttendances(
    request: IPagedRequest
  ): Promise<IPagedResponse<IAttendance>>;
  getById(id: number): Promise<IAttendance>;
  /**
   * Get monthly summary of total hours for all employees for the given month/year
   */
  getMonthlySummary(
    month: number,
    year: number
  ): Promise<IEmployeeMonthlySummary[]>;
  /**
   * Get raw attendance records for a given employee on a specific date (ISO yyyy-mm-dd)
   */
  getByEmployeeAndDate(
    employeeId: string,
    date: string
  ): Promise<IAttendance[]>;
}

export class AttendanceService
  extends BaseService
  implements IAttendanceService
{
  public constructor() {
    super("attendances");
  }

  public async getPagedAttendances(
    request: IPagedRequest
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
    month: number,
    year: number
  ): Promise<IEmployeeMonthlySummary[]> {
    if (USE_MOCKS) {
      return mockMonthlySummary(month, year);
    }

    // API endpoint expected: /attendances/summary?month=...&year=...
    const result = await this.GET<IEmployeeMonthlySummary[]>({
      url: `summary`,
      params: { month, year },
    });

    // Defensive: if API not ready, return empty
    return result ?? [];
  }

  public async getByEmployeeAndDate(
    employeeId: string,
    date: string
  ): Promise<IAttendance[]> {
    if (USE_MOCKS) {
      return mockAttendancesForEmployeeOnDate(employeeId, date);
    }

    // API endpoint expected: /attendances/employee/{id}?date=yyyy-mm-dd
    const result = await this.GET<IAttendance[]>({
      url: `employee/${employeeId}`,
      params: { date },
    });
    return result ?? [];
  }
}
