import { AuthService, type IAuthService } from "../auth-service";
import { UserService, type IUserService } from "../user-service";
import { EmployeeService, type IEmployeeService } from "../employee-service";
import {
  DepartmentService,
  type IDepartmentService,
} from "../department-service";
import { ShiftService, type IShiftService } from "../shift-service";
import { CardService, type ICardService } from "../card-service";
import {
  AttendanceService,
  type IAttendanceService,
} from "../attendance-service";
import { PointService, type IPointService } from "../point-service";
import { SubareaService, type ISubareaService } from "../subarea-service";
import { AreaService, type IAreaService } from "../area-service";
import {
  AssignmentService,
  type IAssignmentService,
} from "../assignment-service";

interface IUnitOfWork {
  authService: IAuthService;
  userService: IUserService;
  employeeService: IEmployeeService;
  departmentService: IDepartmentService;
  shiftService: IShiftService;
  cardService: ICardService;
  attendanceService: IAttendanceService;
  pointService: IPointService;
  subareaService: ISubareaService;
  areaService: IAreaService;
  assignmentService: IAssignmentService;
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

  private _userService: IUserService = new UserService();
  public get userService(): IUserService {
    return (this._userService = this._userService ?? new UserService());
  }

  private _employeeService: IEmployeeService = new EmployeeService();
  public get employeeService(): IEmployeeService {
    return (this._employeeService =
      this._employeeService ?? new EmployeeService());
  }

  private _departmentService: IDepartmentService = new DepartmentService();
  public get departmentService(): IDepartmentService {
    return (this._departmentService =
      this._departmentService ?? new DepartmentService());
  }

  private _shiftService: IShiftService = new ShiftService();
  public get shiftService(): IShiftService {
    return (this._shiftService = this._shiftService ?? new ShiftService());
  }

  private _cardService: ICardService = new CardService();
  public get cardService(): ICardService {
    return (this._cardService = this._cardService ?? new CardService());
  }

  private _attendanceService: IAttendanceService = new AttendanceService();
  public get attendanceService(): IAttendanceService {
    return (this._attendanceService =
      this._attendanceService ?? new AttendanceService());
  }

  private _pointService: IPointService = new PointService();
  public get pointService(): IPointService {
    return (this._pointService = this._pointService ?? new PointService());
  }

  private _subareaService: ISubareaService = new SubareaService();
  public get subareaService(): ISubareaService {
    return (this._subareaService =
      this._subareaService ?? new SubareaService());
  }

  private _areaService: IAreaService = new AreaService();
  public get areaService(): IAreaService {
    return (this._areaService = this._areaService ?? new AreaService());
  }

  private _assignmentService: IAssignmentService = new AssignmentService();
  public get assignmentService(): IAssignmentService {
    return (this._assignmentService =
      this._assignmentService ?? new AssignmentService());
  }
}

export const unitOfWork = UnitOfWork.getUnitOfWork();
