import React, { useState, useEffect } from "react";
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
import { ShiftService } from "@/lib/services/shift-service";
import type { IShift } from "@/lib/interfaces/shift.interface";
import type { IPagedResponse } from "@/lib/interfaces/paged.interface";
import { useLoadingStore } from "~/lib/stores/useLoadingStore";
import { ShiftForm } from "~/components/Forms/ShiftForm";

const ShiftTab: React.FC = () => {
  const [shifts, setShifts] = useState<IShift[]>([]);
  const [shiftDialogOpen, setShiftDialogOpen] = useState(false);
  const [editingShift, setEditingShift] = useState<IShift | null>(null);
  const [currentPage, setCurrentPage] = useState(1);
  const [totalPages, setTotalPages] = useState(1);
  const [totalItems, setTotalItems] = useState(0);
  const pageSize = 10;

  const shiftService = new ShiftService();
  const { show, hide } = useLoadingStore();

  useEffect(() => {
    loadShifts(currentPage);
  }, [currentPage]);

  const loadShifts = async (page: number) => {
    show();
    try {
      const response: IPagedResponse<IShift> =
        await shiftService.getPagedShifts({
          pageIndex: page,
          pageSize,
        });
      setShifts(response.items);
      setTotalPages(Math.ceil(response.totalCount / pageSize));
      setTotalItems(response.totalCount);
    } catch (error) {
      console.error("Error loading shifts:", error);
    } finally {
      hide();
    }
  };

  const handleCreateShift = async (
    shiftData: Omit<IShift, "id" | "createdAt" | "createdBy" | "phanCas">,
  ) => {
    try {
      await shiftService.create(shiftData);
      setShiftDialogOpen(false);
      loadShifts(currentPage);
    } catch (error) {
      console.error("Error creating shift:", error);
    }
  };

  const handleUpdateShift = async (id: number, shiftData: Partial<IShift>) => {
    try {
      await shiftService.update(id, shiftData);
      setShiftDialogOpen(false);
      setEditingShift(null);
      loadShifts(currentPage);
    } catch (error) {
      console.error("Error updating shift:", error);
    }
  };

  const handleDeleteShift = async (id: number) => {
    try {
      await shiftService.delete(id);
      loadShifts(currentPage);
    } catch (error) {
      console.error("Error deleting shift:", error);
    }
  };

  const handlePageChange = (page: number) => {
    setCurrentPage(page);
  };

  return (
    <div className="bg-white p-6 rounded-lg shadow-xl">
      <h2 className="text-2xl font-semibold mb-4 border-b pb-2">
        Định nghĩa Ca làm & Khu vực
      </h2>
      <Dialog open={shiftDialogOpen} onOpenChange={setShiftDialogOpen}>
        <DialogTrigger asChild>
          <Button className="mb-4" onClick={() => setEditingShift(null)}>
            + Tạo Ca làm Mới
          </Button>
        </DialogTrigger>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>
              {editingShift ? "Sửa Ca làm" : "Tạo Ca làm Mới"}
            </DialogTitle>
          </DialogHeader>
          <ShiftForm
            shift={editingShift}
            onSubmit={
              editingShift
                ? (data) => handleUpdateShift(editingShift.id!, data)
                : handleCreateShift
            }
          />
        </DialogContent>
      </Dialog>
      <Table>
        <TableHeader>
          <TableRow>
            <TableHead>Mã Ca</TableHead>
            <TableHead>Tên Ca</TableHead>
            <TableHead>Giờ BĐ</TableHead>
            <TableHead>Giờ KT</TableHead>
            <TableHead>Active</TableHead>
            <TableHead></TableHead>
          </TableRow>
        </TableHeader>
        <TableBody>
          {shifts.map((shift) => (
            <TableRow key={shift.id}>
              <TableCell>{shift.maCa}</TableCell>
              <TableCell>{shift.tenCa}</TableCell>
              <TableCell>{shift.gioBD}</TableCell>
              <TableCell>{shift.gioKT}</TableCell>
              <TableCell>{shift.isActive ? "Yes" : "No"}</TableCell>
              <TableCell>
                <Button
                  variant="outline"
                  size="sm"
                  onClick={() => {
                    setEditingShift(shift);
                    setShiftDialogOpen(true);
                  }}
                >
                  Sửa
                </Button>
                <Button
                  variant="destructive"
                  size="sm"
                  onClick={() => handleDeleteShift(shift.id!)}
                >
                  Xóa
                </Button>
              </TableCell>
            </TableRow>
          ))}
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
          Hiển thị {shifts.length} / {totalItems} ca làm
        </p>
      </div>
    </div>
  );
};

export default ShiftTab;
