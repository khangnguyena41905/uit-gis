// pages/Timekeeping/TimekeepingManagementPage.tsx

import React, { useState, useEffect } from "react";
import type { TimekeepingFilters } from "~/lib/types";
import type { IEmployeeMonthlySummary } from "~/lib/interfaces/timekeeping.interface";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import { Button } from "~/components/ui/button";
import { useNavigate } from "react-router";

// Component giả định cho danh sách (cần tạo)
const TimekeepingList: React.FC<{ data: IEmployeeMonthlySummary[] }> = ({
  data,
}) => (
  <div className="bg-white p-6 rounded-lg shadow-xl">
    <h3 className="text-xl font-semibold mb-4">Danh sách Chấm công</h3>
    {/* Bảng hiển thị data. Sử dụng Link/navigate để đi đến trang chi tiết */}
    <table className="min-w-full divide-y divide-gray-200">
      <thead>
        <tr>
          <th className="text-left p-2">Nhân viên</th>
          <th className="text-left p-2">Giờ (tháng)</th>
          <th className="text-left p-2">Số ngày</th>
          <th className="text-right p-2">Hành động</th>
        </tr>
      </thead>
      <tbody>
        {data.map((item) => (
          <tr key={item.employeeId}>
            <td className="p-2">{item.fullName}</td>
            <td className="p-2">{item.totalHours}</td>
            <td className="p-2">{item.daysWorked ?? 0}</td>
            <td className="p-2 text-right">
              <ActionButton employeeId={item.employeeId} />
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  </div>
);

const ActionButton: React.FC<{ employeeId: string }> = ({ employeeId }) => {
  const navigate = useNavigate();
  return (
    <Button size="sm" onClick={() => navigate(`/timekeeping/${employeeId}`)}>
      Chi tiết
    </Button>
  );
};

const TimekeepingManagementPage: React.FC = () => {
  const [timekeepingData, setTimekeepingData] = useState<
    IEmployeeMonthlySummary[]
  >([]);

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
    try {
      const data = await unitOfWork.attendanceService.getMonthlySummary(
        currentFilters.month,
        currentFilters.year
      );
      setTimekeepingData(data ?? []);
    } catch (err) {
      console.error("Failed to fetch monthly summary", err);
      setTimekeepingData([]);
    }
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
