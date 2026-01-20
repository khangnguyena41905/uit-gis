import React, { useState, useEffect } from "react";

// 2. IMPORT COMPONENT SHADCN UI
import { Button } from "~/components/ui/button"; // Giả định
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
} from "~/components/ui/dialog"; // Giả định
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "~/components/ui/table"; // Giả định
import { Badge } from "~/components/ui/badge"; // Giả định để hiển thị trạng thái
import type { IEmployee } from "~/lib/interfaces/employee.interface";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import { CreateEmployeeForm } from "~/components/Forms/CreateEmployeeForm";
import { useLoadingStore } from "~/lib/stores/useLoadingStore";

const EmployeeManagementPage: React.FC = () => {
  // Cập nhật kiểu dữ liệu state
  const { show, hide } = useLoadingStore();
  const [employees, setEmployees] = useState<IEmployee[]>([]);
  const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
  const [currentEmployee, setCurrentEmployee] = useState<IEmployee | null>(
    null,
  );

  // State cho Phân trang
  const [currentPage, setCurrentPage] = useState(1);
  const [pageSize] = useState(100);

  const fetchEmployees = async () => {
    show();
    const response = await unitOfWork.employeeService.getPagedEmployees({
      pageIndex: currentPage,
      pageSize: pageSize,
    });
    setEmployees(response?.items ?? []);
    hide();
  };

  useEffect(() => {
    fetchEmployees();
  }, [currentPage]);

  const handleEdit = (employee: IEmployee) => {
    setCurrentEmployee(employee);
    setIsModalOpen(true);
  };

  const handleAdd = () => {
    setCurrentEmployee(null);
    setIsModalOpen(true);
  };

  // Tính năng Khóa/Mở khóa
  const handleToggleActive = (employee: IEmployee) => {
    console.log(
      `Đang ${employee.isActive ? "Khóa" : "Mở khóa"} tài khoản ID: ${employee.id}`,
    );
    // Logic gọi API update isActive (sử dụng unitOfWork.employeeService)
    // Sau khi thành công: fetchEmployees();
  };

  // Tính năng Reset Password
  const handleResetPassword = (employee: IEmployee) => {
    if (
      window.confirm(
        `Bạn có chắc chắn muốn RESET MẬT KHẨU cho ${employee.hoTen}?`,
      )
    ) {
      console.log(`Đang Reset mật khẩu cho ID: ${employee.id}`);
      // Logic gọi API Reset Password
    }
  };

  // Tính toán dữ liệu hiển thị cho phân trang (Frontend Paging)
  const totalPages = Math.ceil(employees.length / pageSize);
  const startIndex = (currentPage - 1) * pageSize;
  const currentEmployees = employees.slice(startIndex, startIndex + pageSize);

  // --- JSX RENDER ---
  return (
    <div className="space-y-6">
      {/* HEADER & BUTTON ADD */}
      <div className="flex justify-between items-center">
        <h1 className="text-3xl font-bold text-gray-800">
          👤 Quản lý Tài khoản Nhân viên
        </h1>
        {/* Sử dụng Button Shadcn */}
        <Button onClick={handleAdd}>+ Thêm Nhân viên</Button>
      </div>

      <div className="bg-white p-6 rounded-lg shadow-xl overflow-x-auto">
        {/* 3. SỬ DỤNG SHADCN TABLE */}
        <Table className="min-w-full">
          <TableHeader className="bg-gray-50">
            <TableRow>
              <TableHead className="w-[50px]">ID</TableHead>
              <TableHead className="w-[80px]">Mã NV</TableHead>
              <TableHead>Họ và Tên</TableHead>
              <TableHead>Email</TableHead>
              <TableHead>Phòng Ban</TableHead>
              <TableHead>Vị trí</TableHead>
              <TableHead>Trạng thái</TableHead>
              <TableHead className="text-right w-[250px]">Hành động</TableHead>
            </TableRow>
          </TableHeader>
          <TableBody>
            {currentEmployees.map((emp) => (
              <TableRow key={emp.id}>
                <TableCell className="font-medium">{emp.id}</TableCell>
                <TableCell>{emp.maNV}</TableCell>
                <TableCell>{emp.hoTen}</TableCell>
                <TableCell>{emp.email}</TableCell>
                <TableCell>{emp.department?.tenPB || "N/A"}</TableCell>
                <TableCell>
                  {/* position not defined on IEmployee */}N/A
                </TableCell>
                <TableCell>
                  {/* Sử dụng Badge Shadcn */}
                  <Badge variant={emp.isActive ? "default" : "secondary"}>
                    {emp.isActive ? "Kích hoạt" : "Đã Khóa"}
                  </Badge>
                </TableCell>
                <TableCell className="flex justify-end space-x-2">
                  {/* Button Sửa */}
                  <Button
                    variant="outline"
                    size="sm"
                    onClick={() => handleEdit(emp)}
                  >
                    Sửa
                  </Button>
                  {/* Button Khóa/Mở khóa */}
                  <Button
                    variant={emp.isActive ? "destructive" : "secondary"}
                    size="sm"
                    onClick={() => handleToggleActive(emp)}
                  >
                    {emp.isActive ? "Khóa TK" : "Mở khóa"}
                  </Button>
                  {/* Button Reset Password */}
                  <Button
                    variant="ghost"
                    size="sm"
                    onClick={() => handleResetPassword(emp)}
                  >
                    Reset PW
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>

        {/* PHÂN TRANG */}
        {employees.length > pageSize && (
          <div className="flex justify-between items-center pt-4">
            <p className="text-sm text-gray-500">
              Trang {currentPage} trên {totalPages}
            </p>
            <div className="space-x-2">
              <Button
                variant="outline"
                size="sm"
                onClick={() => setCurrentPage((prev) => Math.max(prev - 1, 1))}
                disabled={currentPage === 1}
              >
                Trang trước
              </Button>
              <Button
                variant="outline"
                size="sm"
                onClick={() =>
                  setCurrentPage((prev) => Math.min(prev + 1, totalPages))
                }
                disabled={currentPage === totalPages}
              >
                Trang sau
              </Button>
            </div>
          </div>
        )}
      </div>

      {/* 4. SHADCN DIALOG (MODAL) CHO THÊM/SỬA */}
      <Dialog open={isModalOpen} onOpenChange={setIsModalOpen}>
        {/* DialogTrigger không cần vì đã có button Add/Edit riêng */}
        <DialogContent className="sm:max-w-[600px]">
          <DialogHeader>
            <DialogTitle>
              {currentEmployee
                ? `Sửa thông tin: ${currentEmployee.hoTen}`
                : "Thêm Nhân viên mới"}
            </DialogTitle>
          </DialogHeader>
          <div className="py-4">
            <CreateEmployeeForm
              onSubmitSuccess={() => {
                setIsModalOpen(false);
                fetchEmployees();
              }}
            />
          </div>
        </DialogContent>
      </Dialog>
    </div>
  );
};

export default EmployeeManagementPage;
