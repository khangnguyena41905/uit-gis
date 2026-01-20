import React, { useCallback, useEffect, useState } from "react";
import Lottie from "react-lottie";
import { formatISO } from "date-fns";
import { Loader2, User, CreditCard, Clock } from "lucide-react";

import { Button } from "@/components/ui/button";
import { Card } from "@/components/ui/card";
import {
  Select,
  SelectTrigger,
  SelectValue,
  SelectContent,
  SelectItem,
} from "@/components/ui/select";
import { Input } from "@/components/ui/input";
import { Label } from "@/components/ui/label";

import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import type { IEmployee } from "~/lib/interfaces/employee.interface";

import faceIdScan from "@/assets/lotties/faceid-scan.json";
import ArcGISMap from "~/components/Timekeeping/ArcGISMap";
import type { ISubarea } from "~/lib/interfaces/subarea.interface";
import { toast } from "sonner";

const Attendance: React.FC = () => {
  const [subarea, setSubarea] = useState<ISubarea[]>([]);
  const [employees, setEmployees] = useState<IEmployee[]>([]);
  const [selectedEmployeeId, setSelectedEmployeeId] = useState<number>();
  const [employeeDetail, setEmployeeDetail] = useState<IEmployee>();

  const [selectedCardId, setSelectedCardId] = useState<number>();
  const [dateTime, setDateTime] = useState<string>("");
  const [selectedLocation, setSelectedLocation] = useState<number>(0);

  const [loading, setLoading] = useState(false);

  /** ---------------- FETCH AREA ---------------- */
  useEffect(() => {
    const fetchArea = async () => {
      const res = await unitOfWork.subareaService.getPagedSubareas({
        pageIndex: 1,
        pageSize: 1000,
      });
      setSubarea(res.items ?? []);
    };
    fetchArea();
  }, []);

  /** ---------------- FETCH EMPLOYEES ---------------- */
  useEffect(() => {
    const fetchEmployees = async () => {
      const res = await unitOfWork.employeeService.getPagedEmployees({
        pageIndex: 1,
        pageSize: 30,
      });
      setEmployees(res.items ?? []);
    };
    fetchEmployees();
  }, []);

  /** ---------------- FETCH EMPLOYEE DETAIL ---------------- */
  useEffect(() => {
    if (!selectedEmployeeId) return;

    const fetchDetail = async () => {
      const res = await unitOfWork.employeeService.getById(
        selectedEmployeeId.toString(),
      );
      setEmployeeDetail(res);
      setSelectedCardId(undefined);
    };

    fetchDetail();
  }, [selectedEmployeeId]);

  /** ---------------- HANDLE CHECK-IN ---------------- */
  const handleCheckin = async () => {
    if (!selectedCardId || !dateTime) return;

    setLoading(true);
    const start = Date.now();

    try {
      await unitOfWork.attendanceService.checkin({
        theId: selectedCardId,
        diaDiemId: selectedLocation ?? 1,
        gio: formatISO(new Date(dateTime)),
      });

      toast.success("Chấm công thành công ");
    } catch (error: any) {
      toast.error(
        error?.response?.data?.message ||
          "Chấm công thất bại. Vui lòng thử lại",
      );
    } finally {
      const elapsed = Date.now() - start;
      const remain = Math.max(2000 - elapsed, 0);

      setTimeout(() => {
        setLoading(false);
      }, remain);
    }
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

  /** ---------------- UI ---------------- */
  return (
    <div>
      <h1 className="text-3xl font-bold flex items-center gap-2">
        <Clock className="h-7 w-7 text-indigo-600" />
        Mô phỏng Chấm công
      </h1>
      <div className="w-full flex gap-2">
        <div className="flex-1 h-[600px]">
          <ArcGISMap
            area={{
              zoom: 18,
            }}
            polygons={getMappedSubarea()}
            onPolygonClick={(polygon) => {
              setSelectedLocation(polygon.firstPointId);
            }}
          />
        </div>
        <div className="w-1/3">
          <Card className="p-6 space-y-4">
            {/* Employee */}
            <div>
              <Label className="flex items-center gap-2">
                <User size={16} /> Nhân viên
              </Label>
              <Select
                value={selectedEmployeeId?.toString()}
                onValueChange={(v) => setSelectedEmployeeId(Number(v))}
              >
                <SelectTrigger>
                  <SelectValue placeholder="Chọn nhân viên" />
                </SelectTrigger>
                <SelectContent>
                  {employees.map((e) => (
                    <SelectItem key={e.id} value={e.id!.toString()}>
                      {e.hoTen}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            {/* Card */}
            <div>
              <Label className="flex items-center gap-2">
                <CreditCard size={16} /> Thẻ từ
              </Label>
              <Select
                disabled={!employeeDetail?.theTus?.length}
                value={selectedCardId?.toString()}
                onValueChange={(v) => setSelectedCardId(Number(v))}
              >
                <SelectTrigger>
                  <SelectValue placeholder="Chọn thẻ từ" />
                </SelectTrigger>
                <SelectContent>
                  {employeeDetail?.theTus?.map((c) => (
                    <SelectItem key={c.id} value={c.id!.toString()}>
                      {c.maThe ?? `Thẻ #${c.maThe}`}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
            </div>

            {/* Datetime */}
            <div>
              <Label>Thời gian chấm công</Label>
              <Input
                type="datetime-local"
                value={dateTime}
                onChange={(e) => setDateTime(e.target.value)}
              />
            </div>
            {/* Location */}
            <div>
              <Label>Vị trí chấm công</Label>
              <Input
                disabled
                placeholder="Chưa chọn vị trí trên bản đồ"
                value={selectedLocation ? `Point ID: ${selectedLocation}` : ""}
              />
            </div>
            {/* Button */}
            <Button
              className="w-full"
              disabled={!selectedCardId || !dateTime || loading}
              onClick={handleCheckin}
            >
              {loading ? (
                <>
                  <Loader2 className="animate-spin mr-2" /> Đang chấm công...
                </>
              ) : (
                "Chấm công"
              )}
            </Button>
          </Card>
        </div>
      </div>

      {/* Loading overlay */}
      {loading && (
        <div className="fixed inset-0 bg-black/50 flex items-center justify-center z-50">
          <div className="bg-white rounded-xl p-6 w-fit">
            <Lottie
              options={{
                animationData: faceIdScan,
                autoplay: true,
                loop: true,
              }}
              width={400}
              height={400}
            />
            <p className="text-center font-medium mt-2">
              Đang xác thực khuôn mặt...
            </p>
          </div>
        </div>
      )}
    </div>
  );
};

export default Attendance;
