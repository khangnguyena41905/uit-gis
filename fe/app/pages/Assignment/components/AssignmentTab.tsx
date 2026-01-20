import React, { useState, useEffect, useCallback } from "react";
import { Button } from "@/components/ui/button";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import {
  Dialog,
  DialogContent,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import {
  Pagination,
  PaginationContent,
  PaginationItem,
  PaginationLink,
  PaginationNext,
  PaginationPrevious,
} from "@/components/ui/pagination";
import type { IAssignment } from "@/lib/interfaces/shift.interface";
import type { IShift } from "@/lib/interfaces/shift.interface";
import type { IPoint } from "@/lib/interfaces/point.interface";
import type { IEmployee } from "@/lib/interfaces/employee.interface";
import type { IPagedResponse } from "@/lib/interfaces/paged.interface";
import { useLoadingStore } from "~/lib/stores/useLoadingStore";
import AssignmentForm from "~/components/Forms/AssignmentForm";
import { toast } from "sonner";
import { handleErrorMessage } from "~/lib/utils";
import ArcGISMap from "~/components/Timekeeping/ArcGISMap";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import type { ISubarea } from "~/lib/interfaces/subarea.interface";

const AssignmentTab: React.FC = () => {
  const [assignments, setAssignments] = useState<IAssignment[]>([]);
  const [shifts, setShifts] = useState<IShift[]>([]);
  const [points, setPoints] = useState<IPoint[]>([]);
  const [employees, setEmployees] = useState<IEmployee[]>([]);
  const [subarea, setSubarea] = useState<ISubarea[]>([]);
  const [assignmentDialogOpen, setAssignmentDialogOpen] = useState(false);
  const [selectedPointId, setSelectedPointId] = useState<number | undefined>();

  const [editingAssignment, setEditingAssignment] =
    useState<IAssignment | null>(null);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [totalItems, setTotalItems] = useState(0);
  const pageSize = 10;

  const { show, hide } = useLoadingStore();

  useEffect(() => {
    loadData();
  }, []);

  useEffect(() => {
    loadAssignments(currentPage);
  }, [currentPage]);

  const loadData = async () => {
    try {
      const [shiftsRes, pointsRes, employeesRes, subareaRes] =
        await Promise.all([
          unitOfWork.shiftService.getPagedShifts({
            pageIndex: 1,
            pageSize: 100,
          }),
          unitOfWork.pointService.getPagedPoints({
            pageIndex: 1,
            pageSize: 100,
          }),
          unitOfWork.employeeService.getPagedEmployees({
            pageIndex: 1,
            pageSize: 100,
          }),
          unitOfWork.subareaService.getPagedSubareas({
            pageIndex: 1,
            pageSize: 1000,
          }),
        ]);
      setShifts(shiftsRes.items);
      setPoints(pointsRes.items);
      setEmployees(employeesRes.items);
      setSubarea(subareaRes.items);
    } catch (error) {
      console.error("Error loading data:", error);
    }
  };

  const loadAssignments = async (page: number) => {
    show();
    try {
      const response: IPagedResponse<IAssignment> =
        await unitOfWork.assignmentService.getPagedAssignments({
          pageIndex: page,
          pageSize,
        });
      setAssignments(response.items);
      setTotalPages(Math.ceil(response.totalCount / pageSize));
      setTotalItems(response.totalCount);
    } catch (error) {
      console.error("Error loading assignments:", error);
    } finally {
      hide();
    }
  };

  const handleCreateAssignment = async (
    assignmentData: Omit<IAssignment, "id" | "createdAt" | "createdBy">,
  ) => {
    try {
      await unitOfWork.assignmentService.create(assignmentData);
      setAssignmentDialogOpen(false);
      loadAssignments(currentPage);
      toast.success("Tạo mới thành công");
    } catch (error) {
      toast.error(handleErrorMessage(error));
    }
  };

  const handleUpdateAssignment = async (
    id: number,
    assignmentData: Partial<IAssignment>,
  ) => {
    try {
      await unitOfWork.assignmentService.update(id, assignmentData);
      setAssignmentDialogOpen(false);
      setEditingAssignment(null);
      loadAssignments(currentPage);
      toast.success("Cập nhật thành công");
    } catch (error) {
      toast.error(handleErrorMessage(error));
    }
  };

  const handleDeleteAssignment = async (id: number) => {
    try {
      await unitOfWork.assignmentService.delete(id);
      loadAssignments(currentPage);
      toast.success("Xóa thành công");
    } catch (error) {
      toast.error(handleErrorMessage(error));
    }
  };

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  const getMappedSubarea = useCallback(() => {
    return subarea
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
          firstPointId: points[0]?.id,
          rings: [points.map((x) => [x?.x, x?.y])],
        };
      });
  }, [subarea]);

  return (
    <div className="bg-white p-6 rounded-lg shadow-xl">
      <h2 className="text-2xl font-semibold mb-4 border-b pb-2">
        Phân công cho Nhân viên
      </h2>
      <Dialog
        open={assignmentDialogOpen}
        onOpenChange={setAssignmentDialogOpen}
      >
        <DialogTrigger asChild>
          <Button className="mb-4" onClick={() => setEditingAssignment(null)}>
            + Phân công Mới
          </Button>
        </DialogTrigger>
        <DialogContent className="min-w-[900px]">
          <DialogHeader>
            <DialogTitle>
              {editingAssignment ? "Sửa Phân công" : "Phân công Mới"}
            </DialogTitle>
          </DialogHeader>
          <div className="flex gap-2">
            <div className="flex-1 h-[300px]">
              <ArcGISMap
                area={{
                  zoom: 18,
                }}
                polygons={getMappedSubarea()}
                onPolygonClick={(polygon) => {
                  setSelectedPointId(polygon.firstPointId);
                }}
              />
            </div>
            <div className="w-[300px]">
              <AssignmentForm
                assignment={editingAssignment}
                selectedPointId={selectedPointId ?? 0}
                shifts={shifts}
                employees={employees}
                points={points}
                onSubmit={
                  editingAssignment
                    ? (data) =>
                        handleUpdateAssignment(editingAssignment.id!, data)
                    : handleCreateAssignment
                }
              />
            </div>
          </div>
        </DialogContent>
      </Dialog>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Nhân viên</TableHead>
            <TableHead>Ca được gán</TableHead>
            <TableHead>Địa điểm</TableHead>
            <TableHead>Ngày BĐ</TableHead>
            <TableHead>Ngày KT</TableHead>
            <TableHead>Active</TableHead>
            <TableHead></TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {assignments.map((assignment) => {
            const employee = employees.find(
              (e) => e.id === assignment.nhanVienId,
            );
            const shift = shifts.find((s) => s.id === assignment.caId);
            const point = points.find((p) => p.id === assignment.diaDiemId);
            return (
              <TableRow key={assignment.id}>
                <TableCell>
                  {employee?.hoTen || assignment.nhanVienId}
                </TableCell>
                <TableCell>{shift?.tenCa || assignment.caId}</TableCell>
                <TableCell>
                  {point?.tenDiaDiem || assignment.diaDiemId}
                </TableCell>
                <TableCell>{assignment.ngayBD}</TableCell>
                <TableCell>{assignment.ngayKT || "N/A"}</TableCell>
                <TableCell>{assignment.isActive ? "Yes" : "No"}</TableCell>
                <TableCell>
                  <Button
                    variant="outline"
                    size="sm"
                    onClick={() => {
                      setEditingAssignment(assignment);
                      setAssignmentDialogOpen(true);
                    }}
                  >
                    Sửa
                  </Button>
                  <Button
                    variant="destructive"
                    size="sm"
                    onClick={() => handleDeleteAssignment(assignment.id!)}
                  >
                    Xóa
                  </Button>
                </TableCell>
              </TableRow>
            );
          })}
        </TableBody>
      </Table>
      <div className="mt-4">
        <Pagination>
          <PaginationContent>
            <PaginationItem>
              <PaginationPrevious
                onClick={() =>
                  currentPage > 1 && handlePageChange(currentPage - 1)
                }
                className={
                  currentPage <= 1 ? "pointer-events-none opacity-50" : ""
                }
              />
            </PaginationItem>
            {Array.from({ length: totalPages }, (_, i) => i + 1).map((page) => (
              <PaginationItem key={page}>
                <PaginationLink
                  onClick={() => handlePageChange(page)}
                  isActive={page === currentPage}
                >
                  {page}
                </PaginationLink>
              </PaginationItem>
            ))}
            <PaginationItem>
              <PaginationNext
                onClick={() =>
                  currentPage < totalPages && handlePageChange(currentPage + 1)
                }
                className={
                  currentPage >= totalPages
                    ? "pointer-events-none opacity-50"
                    : ""
                }
              />
            </PaginationItem>
          </PaginationContent>
        </Pagination>
        <p className="text-sm text-gray-600 mt-2">
          Hiển thị {assignments.length} / {totalItems} phân công
        </p>
      </div>
    </div>
  );
};

export default AssignmentTab;
