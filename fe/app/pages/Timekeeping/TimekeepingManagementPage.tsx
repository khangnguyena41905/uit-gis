// pages/Timekeeping/TimekeepingManagementPage.tsx

import React, { useState, useEffect } from "react";
import type { TimekeepingFilters } from "~/lib/types";
import type { IEmployeeMonthlySummary } from "~/lib/interfaces/timekeeping.interface";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import { Button } from "~/components/ui/button";
import { useNavigate } from "react-router";
import { CalendarIcon } from "lucide-react";
import { format } from "date-fns";

import { Calendar } from "~/components/ui/calendar";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "~/components/ui/popover";
import { useTimeKeepingStore } from "~/lib/stores/useTimeKeepingStore";

// Component giả định cho danh sách (cần tạo)
const TimekeepingList: React.FC<{
  data: IEmployeeMonthlySummary[];
  pageIndex: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}> = ({ data, pageIndex, totalPages, onPageChange }) => (
  <div className="bg-white p-6 rounded-lg shadow-xl space-y-4">
    <h3 className="text-xl font-semibold">Danh sách Chấm công</h3>

    <table className="min-w-full divide-y divide-gray-200">
      <thead>
        <tr className="bg-gray-50">
          <th className="text-left p-2">Nhân viên</th>
          <th className="text-left p-2">Giờ (tháng)</th>
          <th className="text-left p-2">Số ngày</th>
          <th className="text-right p-2">Hành động</th>
        </tr>
      </thead>
      <tbody>
        {data.map((item) => (
          <tr key={item.employeeId} className="hover:bg-gray-50">
            <td className="p-2">{item.fullName}</td>
            <td className="p-2">{Math.ceil(item.totalHours * 100) / 100}</td>
            <td className="p-2">{item.daysWorked ?? 0}</td>
            <td className="p-2 text-right">
              <ActionButton employeeId={item.employeeId} />
            </td>
          </tr>
        ))}
      </tbody>
    </table>

    {/* Pagination */}
    <div className="flex justify-between items-center pt-2">
      <span className="text-sm text-muted-foreground">
        Trang {pageIndex} / {totalPages}
      </span>

      <div className="flex gap-2">
        <Button
          size="sm"
          variant="outline"
          disabled={pageIndex === 1}
          onClick={() => onPageChange(pageIndex - 1)}
        >
          Trước
        </Button>
        <Button
          size="sm"
          variant="outline"
          disabled={pageIndex === totalPages}
          onClick={() => onPageChange(pageIndex + 1)}
        >
          Sau
        </Button>
      </div>
    </div>
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
  const PAGE_SIZE = 5;
  const [pageIndex, setPageIndex] = useState(1);
  const { selectedMonth, setSelectedMonth } = useTimeKeepingStore();
  const totalPages = Math.ceil(timekeepingData.length / PAGE_SIZE);

  const pagedData = timekeepingData.slice(
    (pageIndex - 1) * PAGE_SIZE,
    pageIndex * PAGE_SIZE,
  );

  useEffect(() => {
    setPageIndex(1);
    fetchTimekeepingData(filters, pageIndex);
  }, [filters, pageIndex]);

  const fetchTimekeepingData = async (
    currentFilters: TimekeepingFilters,
    currentPageIndex: number,
  ) => {
    setLoading(true);
    try {
      const data = await unitOfWork.attendanceService.getMonthlySummary({
        month: currentFilters.month,
        year: currentFilters.year,
        pageIndex: currentPageIndex,
        pageSize: PAGE_SIZE,
      });
      setTimekeepingData(data.items ?? []);
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

      <div className="bg-white p-4 rounded-lg shadow flex gap-4 items-center">
        <Popover>
          <PopoverTrigger asChild>
            <Button
              variant="outline"
              className="w-[220px] justify-start text-left font-normal"
            >
              <CalendarIcon className="mr-2 h-4 w-4" />
              {selectedMonth ? (
                format(selectedMonth, "MM / yyyy")
              ) : (
                <span>Chọn tháng</span>
              )}
            </Button>
          </PopoverTrigger>

          <PopoverContent className="w-auto p-0" align="start">
            <Calendar
              mode="single"
              selected={selectedMonth}
              onSelect={(date) => {
                if (!date) return;
                setSelectedMonth(date);
                setFilters({
                  month: date.getMonth() + 1,
                  year: date.getFullYear(),
                });
              }}
              initialFocus
              captionLayout="dropdown"
              fromYear={2020}
              toYear={2030}
            />
          </PopoverContent>
        </Popover>
      </div>

      {loading ? (
        <p className="text-lg text-indigo-600">Đang tải dữ liệu...</p>
      ) : (
        <TimekeepingList
          data={pagedData}
          pageIndex={pageIndex}
          totalPages={totalPages}
          onPageChange={setPageIndex}
        />
      )}
    </div>
  );
};

export default TimekeepingManagementPage;
