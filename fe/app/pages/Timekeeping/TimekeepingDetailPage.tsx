// pages/Timekeeping/TimekeepingDetailPage.tsx

import React, { useState, useEffect } from "react";
import { useParams } from "react-router";
import ArcGISMap from "../../components/Timekeeping/ArcGISMap";
import type { CheckinLocation, Employee } from "~/lib/types";

const TimekeepingDetailPage: React.FC = () => {
  // Lấy params, đảm bảo employeeId là string
  const { employeeId } = useParams<{ employeeId: string }>();
  const [employeeDetails, setEmployeeDetails] = useState<Employee | null>(null);
  const [checkinLocations, setCheckinLocations] = useState<CheckinLocation[]>(
    []
  );
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    if (employeeId) {
      fetchEmployeeData(parseInt(employeeId));
    }
  }, [employeeId]);

  const fetchEmployeeData = async (id: number) => {
    setLoading(true);
    // Giả lập dữ liệu API chi tiết
    const dummyEmployee: Employee = {
      id: id,
      name: `Nhân viên ID: ${id} - Tên Ví dụ`,
      department: "Kỹ thuật",
      position: "Kỹ sư",
      totalHours: 160,
      missedDays: 0,
    };

    const dummyLocations: CheckinLocation[] = [
      {
        id: 1,
        lat: 10.762622,
        lon: 106.660172,
        time: "08:00",
        type: "Check-in (Xưởng A)",
      },
      {
        id: 2,
        lat: 10.772022,
        lon: 106.690572,
        time: "10:30",
        type: "Cà phê (Căn tin)",
      },
      {
        id: 3,
        lat: 10.765122,
        lon: 106.662072,
        time: "17:00",
        type: "Check-out (Cổng B)",
      },
    ];

    await new Promise((resolve) => setTimeout(resolve, 500));

    setEmployeeDetails(dummyEmployee);
    setCheckinLocations(dummyLocations);
    setLoading(false);
  };

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold text-gray-800">
        📍 Chi tiết Chấm công: {employeeDetails?.name || "..."}
      </h1>

      {loading ? (
        <p>Đang tải chi tiết...</p>
      ) : (
        <div className="grid grid-cols-1 lg:grid-cols-3 gap-6">
          <div className="lg:col-span-1 bg-white p-6 rounded-lg shadow h-auto overflow-y-auto">
            <h3 className="text-xl font-semibold mb-4 border-b pb-2">
              Thông tin Chung
            </h3>
            <p>ID: **{employeeDetails?.id}**</p>
            <p>Phòng ban: **{employeeDetails?.department}**</p>

            <h3 className="text-xl font-semibold mt-6 mb-4 border-b pb-2">
              Dữ liệu Chấm công
            </h3>
            <ul className="list-none space-y-2">
              {checkinLocations.map((loc) => (
                <li
                  key={loc.id}
                  className={
                    loc.type.includes("Cà phê")
                      ? "p-2 bg-red-100 rounded"
                      : "p-2"
                  }
                >
                  <p className="font-medium">
                    {loc.time} - **{loc.type}**
                  </p>
                  <p className="text-sm text-gray-500">
                    Tọa độ: {loc.lat}, {loc.lon}
                  </p>
                </li>
              ))}
            </ul>
          </div>

          <div className="lg:col-span-2 bg-white rounded-lg shadow p-0 h-[600px]">
            <ArcGISMap locations={checkinLocations} />
          </div>
        </div>
      )}
    </div>
  );
};

export default TimekeepingDetailPage;
