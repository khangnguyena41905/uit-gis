export interface CheckinLocation {
  id: number;
  lat: number;
  lon: number;
  pointId: number;
  time: string; // Thời gian chấm công (VD: "08:00")
  type?: string; // Loại chấm công (VD: "Check-in", "Check-out", "Cà phê")
}

// export interface Employee {
//   id: number;
//   name: string;
//   department: string;
//   position: string;
//   totalHours: number;
//   missedDays: number;
// }

export interface TimekeepingSummary {
  employeeId: number;
  name: string;
  department: string;
  totalHours: number;
  missedDays: number;
}

export interface TimekeepingFilters {
  month: number;
  year: number;
}

export interface PolygonFeature {
  id: number;
  name?: string;
  diaDiemIds?: number[];
  rings: number[][][]; // rings for polygon geometry
}
