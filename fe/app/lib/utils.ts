import { isAxiosError } from "axios";
import { clsx, type ClassValue } from "clsx";
import { twMerge } from "tailwind-merge";
import type { CheckinLocation, PolygonFeature } from "./types";
import type { IEmployee } from "./interfaces/employee.interface";

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs));
}

export function handleErrorMessage(error: any): string {
  return `${isAxiosError(error) ? error.response?.data : (error.message ?? "Có lỗi xảy ra")}`;
}
export const toLocalISOString = (date: Date) => {
  const tzOffset = date.getTimezoneOffset() * 60000;
  return new Date(date.getTime() - tzOffset).toISOString().slice(0, 19);
};

const isPointInPolygon = (
  point: [number, number],
  polygon: number[][],
): boolean => {
  let inside = false;
  for (let i = 0, j = polygon.length - 1; i < polygon.length; j = i++) {
    const xi = polygon[i][0],
      yi = polygon[i][1];
    const xj = polygon[j][0],
      yj = polygon[j][1];

    const intersect =
      yi > point[1] !== yj > point[1] &&
      point[0] < ((xj - xi) * (point[1] - yi)) / (yj - yi) + xi;

    if (intersect) inside = !inside;
  }
  return inside;
};

export const isValidCheckin = (
  checkin: CheckinLocation,
  employee: IEmployee | null,
  polygons: PolygonFeature[] | undefined,
): boolean => {
  if (!employee?.phanCas || !polygons) return false;

  const checkinDate = new Date(checkin.time);
  checkinDate.setHours(0, 0, 0, 0);

  return employee.phanCas.some((pc) => {
    if (!pc.isActive) return false;

    const from = new Date(pc.ngayBD);
    const to = pc.ngayKT ? new Date(pc.ngayKT) : null;

    from.setHours(0, 0, 0, 0);
    to?.setHours(23, 59, 59, 999);

    if (checkinDate < from || (to && checkinDate > to)) return false;

    const polygon = polygons.find((p) => p.diaDiemIds?.includes(pc.diaDiemId));
    if (!polygon) return false;

    return isPointInPolygon([checkin.lon, checkin.lat], polygon.rings[0]);
  });
};

export const getInitials = (fullName?: string, max = 2) => {
  if (!fullName) return "";

  const words = fullName.trim().split(/\s+/).filter(Boolean);

  if (words.length === 1) {
    return words[0][0].toUpperCase();
  }

  const first = words[0][0];
  const last = words[words.length - 1][0];

  return (first + last).toUpperCase().slice(0, max);
};
export const generateCardCode = () => {
  return `CARD-${Date.now().toString().slice(-6)}`;
};
