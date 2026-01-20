import { useEffect, useState } from "react";
import type { ICard } from "~/lib/interfaces/card.interface";
import type { IEmployee } from "~/lib/interfaces/employee.interface";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import { useLoadingStore } from "~/lib/stores/useLoadingStore";
import { generateCardCode } from "~/lib/utils";

import { Card, CardContent, CardHeader, CardTitle } from "@/components/ui/card";
import {
  Table,
  TableBody,
  TableCell,
  TableHead,
  TableHeader,
  TableRow,
} from "@/components/ui/table";
import { Button } from "@/components/ui/button";
import {
  Dialog,
  DialogContent,
  DialogFooter,
  DialogHeader,
  DialogTitle,
  DialogTrigger,
} from "@/components/ui/dialog";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { Label } from "@/components/ui/label";
import { Input } from "@/components/ui/input";

export default function CardManagement() {
  const [cards, setCards] = useState<ICard[]>([]);
  const [employees, setEmployees] = useState<IEmployee[]>([]);
  const [pageIndex, setPageIndex] = useState(1);

  const [open, setOpen] = useState(false);
  const [selectedEmployeeId, setSelectedEmployeeId] = useState<number | null>(
    null,
  );
  const [cardCode, setCardCode] = useState("");

  const { show, hide } = useLoadingStore();

  /* ================= FETCH ================= */
  const fetchCards = async () => {
    try {
      show();
      const res = await unitOfWork.cardService.getPagedCards({
        pageIndex,
        pageSize: 10,
      });
      setCards(res.items);
    } finally {
      hide();
    }
  };

  const fetchEmployees = async () => {
    const res = await unitOfWork.employeeService.getPagedEmployees({
      pageIndex: 1,
      pageSize: 100,
    });
    setEmployees(res.items);
  };

  useEffect(() => {
    fetchCards();
  }, [pageIndex]);

  useEffect(() => {
    fetchEmployees();
  }, []);

  /* ================= CREATE ================= */
  const handleOpenModal = () => {
    setCardCode(generateCardCode());
    setSelectedEmployeeId(null);
    setOpen(true);
  };

  const handleCreateCard = async () => {
    if (!selectedEmployeeId) return;

    await unitOfWork.cardService.create({
      nhanVienId: selectedEmployeeId,
      ngayCap: new Date().toISOString().slice(0, 10),
      maThe: cardCode,
      isActive: true,
    });

    setOpen(false);
    fetchCards();
  };

  /* ================= DELETE ================= */
  const handleDelete = async (id: number) => {
    if (!confirm("Xóa thẻ này?")) return;
    await unitOfWork.cardService.delete(id);
    fetchCards();
  };

  return (
    <Card>
      <CardHeader className="flex flex-row items-center justify-between">
        <CardTitle>Quản lý thẻ từ</CardTitle>

        {/* ===== ADD BUTTON ===== */}
        <Button onClick={handleOpenModal}>+ Thêm thẻ</Button>
      </CardHeader>

      <CardContent className="space-y-4">
        {/* ===== TABLE ===== */}
        <Table>
          <TableHeader>
            <TableRow>
              <TableHead>Mã NV</TableHead>
              <TableHead>Tên NV</TableHead>
              <TableHead>Mã thẻ</TableHead>
              <TableHead className="w-[80px] text-center"></TableHead>
            </TableRow>
          </TableHeader>

          <TableBody>
            {cards.length === 0 && (
              <TableRow>
                <TableCell
                  colSpan={4}
                  className="text-center text-muted-foreground"
                >
                  Không có dữ liệu
                </TableCell>
              </TableRow>
            )}

            {cards.map((c) => (
              <TableRow key={c.id}>
                <TableCell>{c.nhanVien?.maNV}</TableCell>
                <TableCell>{c.nhanVien?.hoTen}</TableCell>
                <TableCell className="font-mono">{c.maThe}</TableCell>
                <TableCell className="text-center">
                  <Button
                    size="sm"
                    variant="destructive"
                    onClick={() => handleDelete(c.id!)}
                  >
                    Xóa
                  </Button>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>

        {/* ===== PAGINATION ===== */}
        <div className="flex justify-end gap-2">
          <Button
            variant="outline"
            size="sm"
            disabled={pageIndex === 1}
            onClick={() => setPageIndex((p) => Math.max(1, p - 1))}
          >
            ← Trước
          </Button>

          <span className="text-sm text-muted-foreground">
            Trang {pageIndex}
          </span>

          <Button
            variant="outline"
            size="sm"
            onClick={() => setPageIndex((p) => p + 1)}
          >
            Sau →
          </Button>
        </div>
      </CardContent>

      {/* ================= MODAL ================= */}
      <Dialog open={open} onOpenChange={setOpen}>
        <DialogContent>
          <DialogHeader>
            <DialogTitle>Thêm thẻ mới</DialogTitle>
          </DialogHeader>

          <div className="space-y-4">
            {/* Nhân viên */}
            <div className="space-y-1">
              <Label>Nhân viên</Label>
              <Select onValueChange={(v) => setSelectedEmployeeId(Number(v))}>
                <SelectTrigger>
                  <SelectValue placeholder="Chọn nhân viên" />
                </SelectTrigger>
                <SelectContent>
                  {employees.map((e) => (
                    <SelectItem key={e.id} value={e.id!.toString()}>
                      {e.maNV} - {e.hoTen}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            {/* Mã thẻ */}
            <div className="space-y-1">
              <Label>Mã thẻ</Label>
              <Input value={cardCode} readOnly />
            </div>
          </div>

          <DialogFooter>
            <Button variant="outline" onClick={() => setOpen(false)}>
              Hủy
            </Button>
            <Button onClick={handleCreateCard}>Tạo thẻ</Button>
          </DialogFooter>
        </DialogContent>
      </Dialog>
    </Card>
  );
}
