// pages/Timekeeping/TimekeepingDetailPage.tsx

import React, { useState, useEffect, use, useCallback } from "react";
import { useParams } from "react-router";
import ArcGISMap from "../../components/Timekeeping/ArcGISMap";
import type { CheckinLocation } from "~/lib/types";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import type { PolygonFeature } from "~/lib/types";
import { useTimeKeepingStore } from "~/lib/stores/useTimeKeepingStore";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";
import { Calendar } from "~/components/ui/calendar";
import { Button } from "~/components/ui/button";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "~/components/ui/popover";
import type { IEmployee } from "~/lib/interfaces/employee.interface";
import { isValidCheckin } from "~/lib/utils";
import { useMetadataStore } from "~/lib/stores/useMetadataStore";
import { useLoadingStore } from "~/lib/stores/useLoadingStore";

const TimekeepingDetailPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const { selectedMonth } = useTimeKeepingStore();
  const departments = useMetadataStore((state) => state.departments);
  const [employeeDetails, setEmployeeDetails] = useState<IEmployee | null>(
    null,
  );
  const [checkinLocations, setCheckinLocations] = useState<CheckinLocation[]>(
    [],
  );
  const [polygons, setPolygons] = useState<PolygonFeature[] | undefined>(
    undefined,
  );
  const { show, hide } = useLoadingStore();
  const [date, setDate] = useState<Date | undefined>(selectedMonth);

  useEffect(() => {
    if (id) {
      fetchData();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id, date]);

  const fetchData = async () => {
    show();
    try {
      if (id) {
        try {
          const subareaResp = await unitOfWork.subareaService.getPagedSubareas({
            pageIndex: 1,
            pageSize: 1000,
          });
          const features: PolygonFeature[] = (subareaResp?.items ?? [])
            .filter(
              (s) =>
                s.diem_PhanKhus.flatMap((dpk) => dpk.diem).length > 0 &&
                s.maPhanKhu !== undefined,
            )
            .map((s) => {
              const points = s.diem_PhanKhus.flatMap((x) => x.diem);

              return {
                id: s.id as number,
                name: s.tenPhanKhu,
                diaDiemIds: points.map((p) => p.id || 0),
                rings: [
                  s.diem_PhanKhus.flatMap((x) => x.diem).map((x) => [x.x, x.y]),
                ],
              };
            });
          setPolygons(features.length > 0 ? features : undefined);

          const emp = await unitOfWork.employeeService.getById(id);
          setEmployeeDetails(emp);
        } catch (err) {
          console.warn("Failed to fetch employee", err);
        }
      }

      if (!date) return;
      const fromDate = new Date(date);
      fromDate.setHours(0, 0, 0, 0);

      const toDate = new Date(date);
      toDate.setHours(23, 59, 59, 999);
      const attends = await unitOfWork.attendanceService.getAttendanceHistory(
        Number(id),
        fromDate,
        toDate,
      );

      const checkins: CheckinLocation[] = (attends ?? [])
        .map((a) => {
          if (!a.diem) return null;
          return {
            id: a.id,
            lat: Number(a.diem.y),
            lon: Number(a.diem.x),
            pointId: a.diaDiemId,
            time: a.gio,
          } as CheckinLocation;
        })
        .filter(Boolean) as CheckinLocation[];

      setCheckinLocations(checkins);
    } catch (err) {
      console.error("Failed to load timekeeping detail", err);
    }
    hide();
  };

  const getCheckinPoint = useCallback(() => {
    return checkinLocations.map((loc) => {
      const valid = isValidCheckin(loc, employeeDetails, polygons);

      return {
        lat: loc.lat,
        lon: loc.lon,
        color: valid ? "#2e7d32" : "#c62828",
        popup: {
          title: valid ? "Chấm công hợp lệ" : "Ngoài phân ca",
          content: new Date(loc.time).toLocaleTimeString(),
        },
      };
    });
  }, [checkinLocations, employeeDetails, polygons]);

  const getArea = useCallback(() => {
    const firstItem = polygons?.[0];
    return {
      ...firstItem,
      x: firstItem?.rings[0][0][0],
      y: firstItem?.rings[0][0][1],
    };
  }, [polygons]);

  const getDepartmentName = (id: number) => {
    return departments.filter((d) => d.id == id)[0];
  };

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold text-gray-800">
        📍 Chi tiết Chấm công:{" "}
        {employeeDetails?.hoTen || `NV: ${employeeDetails?.maNV}`}
      </h1>

      <div className="bg-white p-4 rounded-lg shadow flex items-center space-x-4">
        <label className="text-sm font-medium">Chọn ngày:</label>

        <Popover>
          <PopoverTrigger asChild>
            <Button
              variant="outline"
              className="w-[200px] justify-start text-left font-normal"
            >
              <CalendarIcon className="mr-2 h-4 w-4" />
              {date ? format(date, "dd/MM/yyyy") : "Chọn ngày"}
            </Button>
          </PopoverTrigger>

          <PopoverContent className="w-auto p-0" align="start">
            <Calendar
              mode="single"
              selected={date}
              onSelect={setDate}
              initialFocus
            />
          </PopoverContent>
        </Popover>
      </div>

      <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
        <div className="lg:col-span-1 bg-white p-6 rounded-lg shadow h-auto overflow-y-auto">
          <h3 className="text-xl font-semibold mb-4 border-b pb-2">
            Thông tin Chung
          </h3>
          <p>
            ID: <strong>{employeeDetails?.maNV ?? id}</strong>
          </p>
          <p>
            Phòng ban:
            <strong>
              {employeeDetails?.phongBanId
                ? getDepartmentName(employeeDetails?.phongBanId)?.tenPB
                : ""}
            </strong>
          </p>

          <h3 className="text-xl font-semibold mt-6 mb-4 border-b pb-2">
            Dữ liệu Chấm công ({date?.toLocaleDateString()})
          </h3>
          <ul className="list-none space-y-2">
            {checkinLocations.map((loc) => (
              <li key={loc.id} className="p-2 bg-gray-50 rounded">
                <p className="font-medium">
                  {new Date(loc.time).toLocaleTimeString() || loc.time} -{" "}
                  <strong>{loc.type ?? ""}</strong>
                </p>
                <p className="text-sm text-gray-500">
                  Tọa độ: {loc.lat}, {loc.lon}
                </p>
              </li>
            ))}
            {checkinLocations.length === 0 && (
              <li>Không có dữ liệu chấm công trong ngày</li>
            )}
          </ul>
        </div>

        <div className="lg:col-span-2 bg-white rounded-lg shadow p-0 h-[600px]">
          <ArcGISMap
            area={{
              center: [getArea().x ?? 0, getArea().y ?? 0],
              zoom: 18,
            }}
            points={getCheckinPoint()}
            polygons={polygons}
          />
        </div>
      </div>
    </div>
  );
};

export default TimekeepingDetailPage;
