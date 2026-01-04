import type { IEmployeeMonthlySummary } from "../interfaces/timekeeping.interface";
import type { IAttendance } from "../interfaces/attendance.interface";
import type { ISubarea } from "../interfaces/subarea.interface";

export const mockMonthlySummary = (
  month: number,
  year: number
): IEmployeeMonthlySummary[] => {
  // Simple deterministic mock
  return [
    {
      employeeId: "101",
      fullName: "Nguyễn Văn A",
      totalHours: 168,
      daysWorked: 22,
    },
    {
      employeeId: "102",
      fullName: "Trần Thị B",
      totalHours: 176,
      daysWorked: 22,
    },
    {
      employeeId: "103",
      fullName: "Lê Văn C",
      totalHours: 152,
      daysWorked: 20,
    },
  ];
};

export const mockAttendancesForEmployeeOnDate = (
  employeeId: string,
  date: string
): IAttendance[] => {
  // Return a few sample checkins for the day using different coordinates
  return [
    {
      id: 1,
      cardId: "T-001",
      pointId: 11,
      location: "Cổng chính",
      time: `${date}T08:03:00Z`,
      card: {
        id: "T-001",
        employeeId,
        issuedDate: undefined,
        isActive: true,
        note: null,
      },
      point: { id: 11, x: 106.791739, y: 10.859193, name: "Cổng chính" },
    } as IAttendance,
    {
      id: 2,
      cardId: "T-001",
      pointId: 12,
      location: "Xưởng A",
      time: `${date}T12:15:00Z`,
      card: {
        id: "T-001",
        employeeId,
        issuedDate: undefined,
        isActive: true,
        note: null,
      },
      point: { id: 12, x: 106.791995, y: 10.858444, name: "Xưởng A" },
    } as IAttendance,
    {
      id: 3,
      cardId: "T-001",
      pointId: 13,
      location: "Cổng ra",
      time: `${date}T17:05:00Z`,
      card: {
        id: "T-001",
        employeeId,
        issuedDate: undefined,
        isActive: true,
        note: null,
      },
      point: { id: 13, x: 106.791739, y: 10.859193, name: "Cổng ra" },
    } as IAttendance,
  ];
};

// export const mockSubareas = (): ISubarea[] => {
//   return [
//     {
//       id: 1,
//       name: "Khu vực A",
//       areaId: 1,
//       polygons: [
//         [
//           [106.655, 10.76],
//           [106.665, 10.76],
//           [106.665, 10.765],
//           [106.655, 10.765],
//           [106.655, 10.76],
//         ],
//       ],
//     } as ISubarea,
//     {
//       id: 2,
//       name: "Khu vực B",
//       areaId: 1,
//       polygons: [
//         [
//           [106.669, 10.768],
//           [106.68, 10.768],
//           [106.68, 10.774],
//           [106.669, 10.774],
//           [106.669, 10.768],
//         ],
//       ],
//     } as ISubarea,
//   ];
// };

export const mockSubareas = (): ISubarea[] => {
  return [
    {
      id: 1,
      name: "Khu vực A",
      areaId: 1,
      polygons: [
        [
          [106.791977, 10.858709],
          [106.791705, 10.859167],
          [106.793369, 10.860146],
          [106.79367, 10.859708],
        ],
      ],
    } as ISubarea,
    {
      id: 2,
      name: "Khu vực B",
      areaId: 1,
      polygons: [
        [
          [106.79247900868387, 10.85872537137913],
          [106.7919923456075, 10.858460591874959],
          [106.7921796994679, 10.858146446396075],
          [106.79225738277586, 10.858184592650417],
          [106.79235105970604, 10.858025275908794],
          [106.79276232427762, 10.858258641247895],
        ],
      ],
    } as ISubarea,
    {
      id: 3,
      name: "Khu vực C",
      areaId: 1,
      polygons: [
        [
          [106.7924950023061, 10.85872537137913],
          [106.79272805222998, 10.85886898050355],
          [106.79295881735071, 10.858485274720003],
          [106.79272119782046, 10.858346153203055],
        ],
      ],
    } as ISubarea,
  ];
};
