export interface IEmployeeMonthlySummary {
  employeeId: string;
  fullName: string;
  totalHours: number; // total working hours in the month
  daysWorked?: number;
}
