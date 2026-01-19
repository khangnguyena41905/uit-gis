namespace GIS.API.Models.Dto;

public class EmployeeMonthlyAttendanceSummaryDto
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public double TotalHours { get; set; }
    public int DaysWorked { get; set; }
}