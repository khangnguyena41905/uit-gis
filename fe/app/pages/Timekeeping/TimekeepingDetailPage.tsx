// pages/Timekeeping/TimekeepingDetailPage.tsx

import React, { useState, useEffect, use } from "react";
import { useParams } from "react-router";
import ArcGISMap from "../../components/Timekeeping/ArcGISMap";
import type { CheckinLocation, Employee } from "~/lib/types";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import type { PolygonFeature } from "~/lib/types";

const TimekeepingDetailPage: React.FC = () => {
  // Lấy params (id), đảm bảo hợp lệ
  const { id } = useParams<{ id: string }>();
  const [employeeDetails, setEmployeeDetails] = useState<Employee | null>(null);
  const [checkinLocations, setCheckinLocations] = useState<CheckinLocation[]>(
    []
  );
  const [polygons, setPolygons] = useState<PolygonFeature[] | undefined>(
    undefined
  );
  const [loading, setLoading] = useState<boolean>(true);
  const [date, setDate] = useState<string>(() => {
    const d = new Date();
    return d.toISOString().slice(0, 10);
  });

  useEffect(() => {
    if (id) {
      fetchData();
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [id, date]);

  const fetchData = async () => {
    setLoading(true);
    try {
      // Employee details
      if (id) {
        try {
          const emp = await unitOfWork.employeeService.getById(id);
          setEmployeeDetails({
            id: Number(emp.id),
            name: emp.fullName,
            department: emp.department?.name ?? "",
            position: "",
            totalHours: 0,
            missedDays: 0,
          });
        } catch (err) {
          // silently continue with null employee
          console.warn("Failed to fetch employee", err);
        }
      }

      // Attendances for the day
      const attends = await unitOfWork.attendanceService.getByEmployeeAndDate(
        id as string,
        date
      );

      const checkins: CheckinLocation[] = (attends ?? [])
        .map((a) => {
          if (!a.point) return null;
          return {
            id: a.id,
            lat: Number(a.point.y),
            lon: Number(a.point.x),
            time: a.time,
            type: a.location ?? "",
          } as CheckinLocation;
        })
        .filter(Boolean) as CheckinLocation[];

      setCheckinLocations(checkins);

      // Subareas / polygons to draw
      const subareaResp = await unitOfWork.subareaService.getPagedSubareas({
        pageIndex: 1,
        pageSize: 1000,
      });
      const features: PolygonFeature[] = (subareaResp?.items ?? [])
        .filter((s) => s.polygons && s.polygons.length > 0)
        .map((s) => ({ id: s.id, name: s.name, rings: s.polygons! }));

      setPolygons(features.length > 0 ? features : undefined);
    } catch (err) {
      console.error("Failed to load timekeeping detail", err);
    }
    setLoading(false);
  };

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold text-gray-800">
        📍 Chi tiết Chấm công: {employeeDetails?.name || `NV: ${id}`}
      </h1>

      <div className="bg-white p-4 rounded-lg shadow flex items-center space-x-4">
        <label className="text-sm">Chọn ngày:</label>
        <input
          type="date"
          value={date}
          onChange={(e) => setDate(e.target.value)}
          className="border p-2 rounded"
        />
      </div>

      {loading ? (
        <p>Đang tải chi tiết...</p>
      ) : (
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          <div className="lg:col-span-1 bg-white p-6 rounded-lg shadow h-auto overflow-y-auto">
            <h3 className="text-xl font-semibold mb-4 border-b pb-2">
              Thông tin Chung
            </h3>
            <p>
              ID: <strong>{employeeDetails?.id ?? id}</strong>
            </p>
            <p>
              Phòng ban: <strong>{employeeDetails?.department}</strong>
            </p>

            <h3 className="text-xl font-semibold mt-6 mb-4 border-b pb-2">
              Dữ liệu Chấm công ({date})
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
            <ArcGISMap locations={checkinLocations} polygons={polygons} />
          </div>
        </div>
      )}
    </div>
  );
};

export default TimekeepingDetailPage;
