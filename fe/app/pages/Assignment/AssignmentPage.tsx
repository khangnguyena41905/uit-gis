// src/pages/Assignment/AssignmentPage.tsx

import React, { useState, useEffect } from "react";

// Định nghĩa kiểu dữ liệu cho Ca làm việc
interface Shift {
  id: number;
  name: string;
  timeRange: string; // VD: "08:00 - 17:00"
  locationBoundary: string; // VD: "Xưởng A, Bán kính 50m"
}

// Định nghĩa kiểu dữ liệu cho Phân công
interface Assignment {
  id: number;
  employeeName: string;
  shiftName: string;
  dateRange: string;
}

const dummyShifts: Shift[] = [
  {
    id: 1,
    name: "Ca Hành chính",
    timeRange: "08:00 - 17:00",
    locationBoundary: "Khu Văn phòng/Xưởng A",
  },
  {
    id: 2,
    name: "Ca Sản xuất 1",
    timeRange: "06:00 - 14:00",
    locationBoundary: "Toàn bộ Khu vực Sản xuất",
  },
];

const dummyAssignments: Assignment[] = [
  {
    id: 101,
    employeeName: "Lê Văn Chính",
    shiftName: "Ca Sản xuất 1",
    dateRange: "01/01/2026 - 31/01/2026",
  },
  {
    id: 102,
    employeeName: "Nguyễn Thị Hoa",
    shiftName: "Ca Hành chính",
    dateRange: "01/01/2026 - 31/12/2026",
  },
];

const AssignmentPage: React.FC = () => {
  const [shifts, setShifts] = useState<Shift[]>([]);
  const [assignments, setAssignments] = useState<Assignment[]>([]);
  const [loading, setLoading] = useState<boolean>(true);

  useEffect(() => {
    // Giả lập gọi API lấy danh sách ca làm và phân công
    setTimeout(() => {
      setShifts(dummyShifts);
      setAssignments(dummyAssignments);
      setLoading(false);
    }, 500);
  }, []);

  // Nút Thêm Ca làm, Thêm Phân công, Sửa...

  return (
    <div className="space-y-8">
      <h1 className="text-3xl font-bold text-gray-800">
        📅 Phân công Ca làm việc
      </h1>

      {loading ? (
        <p>Đang tải dữ liệu phân công...</p>
      ) : (
        <>
          {/* Phần Quản lý Ca làm việc Mẫu */}
          <div className="bg-white p-6 rounded-lg shadow-xl">
            <h2 className="text-2xl font-semibold mb-4 border-b pb-2">
              1. Định nghĩa Ca làm & Khu vực
            </h2>
            <button className="mb-4 px-4 py-2 bg-green-600 text-white rounded-lg hover:bg-green-700">
              + Tạo Ca làm Mới
            </button>
            <table className="min-w-full divide-y divide-gray-200">
              <thead className="bg-gray-50">
                <tr>
                  <th className="px-6 py-3 text-left">Tên Ca</th>
                  <th className="px-6 py-3 text-left">Thời gian</th>
                  <th className="px-6 py-3 text-left">Giới hạn Vị trí</th>
                  <th className="px-6 py-3"></th>
                </tr>
              </thead>
              <tbody>
                {shifts.map((shift) => (
                  <tr key={shift.id}>
                    <td className="px-6 py-4">{shift.name}</td>
                    <td className="px-6 py-4">{shift.timeRange}</td>
                    <td className="px-6 py-4">{shift.locationBoundary}</td>
                    <td className="px-6 py-4">... Sửa/Xóa ...</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>

          {/* Phần Gán Ca làm cho Nhân viên */}
          <div className="bg-white p-6 rounded-lg shadow-xl">
            <h2 className="text-2xl font-semibold mb-4 border-b pb-2">
              2. Phân công cho Nhân viên
            </h2>
            <button className="mb-4 px-4 py-2 bg-indigo-600 text-white rounded-lg hover:bg-indigo-700">
              + Phân công Mới
            </button>
            <table className="min-w-full divide-y divide-gray-200">
              {/* ... Bảng danh sách phân công Assignments ... */}
              <thead>
                <tr>
                  <th className="px-6 py-3 text-left">Nhân viên</th>
                  <th className="px-6 py-3 text-left">Ca được gán</th>
                  <th className="px-6 py-3 text-left">Thời gian áp dụng</th>
                  <th className="px-6 py-3"></th>
                </tr>
              </thead>
              <tbody>
                {assignments.map((assignment) => (
                  <tr key={assignment.id}>
                    <td className="px-6 py-4">{assignment.employeeName}</td>
                    <td className="px-6 py-4">{assignment.shiftName}</td>
                    <td className="px-6 py-4">{assignment.dateRange}</td>
                    <td className="px-6 py-4">... Sửa/Xóa ...</td>
                  </tr>
                ))}
              </tbody>
            </table>
          </div>
        </>
      )}
    </div>
  );
};

export default AssignmentPage;
