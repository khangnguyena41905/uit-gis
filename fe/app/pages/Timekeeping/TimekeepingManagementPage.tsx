// pages/Timekeeping/TimekeepingManagementPage.tsx

import React, { useState, useEffect } from "react";
import type { TimekeepingFilters, TimekeepingSummary } from "~/lib/types";

// Component giả định cho danh sách (cần tạo)
const TimekeepingList: React.FC<{ data: TimekeepingSummary[] }> = ({
  data,
}) => (
  <div className="bg-white p-6 rounded-lg shadow-xl">
    <h3 className="text-xl font-semibold mb-4">Danh sách Chấm công</h3>
    {/* Bảng hiển thị data. Sử dụng Link/navigate để đi đến trang chi tiết */}
    <table className="min-w-full divide-y divide-gray-200">
      <thead> {/* ... Table Headings ... */} </thead>
      <tbody>
        {data.map((item) => (
          <tr key={item.employeeId}>
            <td>{item.name}</td>
            <td>{item.department}</td>
            <td>{item.totalHours}</td>
            {/* Thêm cột Link đến /timekeeping/${item.employeeId} */}
          </tr>
        ))}
      </tbody>
    </table>
  </div>
);

const TimekeepingManagementPage: React.FC = () => {
  const [timekeepingData, setTimekeepingData] = useState<TimekeepingSummary[]>(
    []
  );

  const initialFilters: TimekeepingFilters = {
    month: new Date().getMonth() + 1,
    year: new Date().getFullYear(),
  };
  const [filters, setFilters] = useState<TimekeepingFilters>(initialFilters);
  const [loading, setLoading] = useState<boolean>(false);

  useEffect(() => {
    fetchTimekeepingData(filters);
  }, [filters]);

  const fetchTimekeepingData = async (currentFilters: TimekeepingFilters) => {
    setLoading(true);
    console.log("Fetching data with filters:", currentFilters);

    // Giả lập dữ liệu API
    const dummyData: TimekeepingSummary[] = [
      {
        employeeId: 101,
        name: "Nguyễn Văn A",
        department: "Kỹ thuật",
        totalHours: 160,
        missedDays: 2,
      },
      {
        employeeId: 102,
        name: "Trần Thị B",
        department: "Hành chính",
        totalHours: 176,
        missedDays: 0,
      },
    ];

    // Thao tác với API ở đây
    await new Promise((resolve) => setTimeout(resolve, 500));

    setTimekeepingData(dummyData);
    setLoading(false);
  };

  return (
    <div className="space-y-6">
      <h1 className="text-3xl font-bold text-gray-800">
        ⏰ Quản lý Chấm công Tổng quan
      </h1>

      {/* Bộ lọc */}
      <div className="bg-white p-4 rounded-lg shadow flex space-x-4">
        <select
          onChange={(e) =>
            setFilters({ ...filters, month: parseInt(e.target.value) })
          }
          value={filters.month}
          className="border p-2 rounded"
        >
          {/* Options cho Tháng */}
          {[...Array(12)].map((_, i) => (
            <option key={i + 1} value={i + 1}>
              Tháng {i + 1}
            </option>
          ))}
        </select>
        {/* Thêm các bộ lọc khác (Năm, Phòng ban) */}
      </div>

      {loading ? (
        <p className="text-lg text-indigo-600">Đang tải dữ liệu...</p>
      ) : (
        <TimekeepingList data={timekeepingData} />
      )}
    </div>
  );
};

export default TimekeepingManagementPage;
