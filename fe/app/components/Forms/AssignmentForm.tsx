import React from "react";
import type { IEmployee } from "~/lib/interfaces/employee.interface";
import type { IPoint } from "~/lib/interfaces/point.interface";
import type { IAssignment, IShift } from "~/lib/interfaces/shift.interface";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";
import {
  assignmentSchema,
  type AssignmentFormValues,
} from "~/lib/schemas/assignmentSchema";
import { format } from "date-fns";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import {
  Popover,
  PopoverContent,
  PopoverTrigger,
} from "@/components/ui/popover";
import { CalendarIcon } from "lucide-react";
import { Calendar } from "@/components/ui/calendar";
import { DialogFooter } from "@/components/ui/dialog";

export interface AssignmentFormProps {
  assignment: IAssignment | null;
  shifts: IShift[];
  employees: IEmployee[];
  points: IPoint[];
  onSubmit: (data: any) => void;
}

export const AssignmentForm: React.FC<AssignmentFormProps> = ({
  assignment,
  shifts,
  employees,
  points,
  onSubmit,
}) => {
  const form = useForm<AssignmentFormValues>({
    resolver: zodResolver(assignmentSchema),
    defaultValues: {
      caId: assignment?.caId ?? 0,
      nhanVienId: assignment?.nhanVienId ?? 0,
      diaDiemId: assignment?.diaDiemId ?? 0,
      ngayBD: assignment?.ngayBD ? new Date(assignment.ngayBD) : undefined,
      ngayKT: assignment?.ngayKT ? new Date(assignment.ngayKT) : undefined,
      isActive: assignment?.isActive ?? true,
    },
  });

  const handleSubmit = (values: AssignmentFormValues) => {
    onSubmit({
      ...values,
      ngayBD: format(values.ngayBD, "yyyy-MM-dd"),
      ngayKT: values.ngayKT ? format(values.ngayKT, "yyyy-MM-dd") : null,
    });
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-4">
        {/* Ca làm */}
        <FormField
          control={form.control}
          name="caId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Ca làm</FormLabel>
              <Select
                value={field.value?.toString()}
                onValueChange={(v) => field.onChange(Number(v))}
              >
                <FormControl>
                  <SelectTrigger className="w-full">
                    <SelectValue placeholder="Chọn ca làm" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {shifts.map((s) => (
                    <SelectItem key={s.id} value={s.id!.toString()}>
                      {s.tenCa}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Nhân viên */}
        <FormField
          control={form.control}
          name="nhanVienId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Nhân viên</FormLabel>
              <Select
                value={field.value?.toString()}
                onValueChange={(v) => field.onChange(Number(v))}
              >
                <FormControl>
                  <SelectTrigger className="w-full">
                    <SelectValue placeholder="Chọn nhân viên" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {employees.map((e) => (
                    <SelectItem key={e.id} value={e.id!.toString()}>
                      {e.hoTen}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Địa điểm */}
        <FormField
          control={form.control}
          name="diaDiemId"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Địa điểm</FormLabel>
              <Select
                value={field.value?.toString()}
                onValueChange={(v) => field.onChange(Number(v))}
              >
                <FormControl>
                  <SelectTrigger className="w-full">
                    <SelectValue placeholder="Chọn địa điểm" />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  {points.map((p) => (
                    <SelectItem key={p.id} value={p.id!.toString()}>
                      {p.tenDiaDiem}
                    </SelectItem>
                  ))}
                </SelectContent>
              </Select>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Ngày BĐ */}
        <FormField
          control={form.control}
          name="ngayBD"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Ngày bắt đầu</FormLabel>
              <Popover>
                <PopoverTrigger asChild>
                  <FormControl>
                    <Button variant="outline" className="w-full justify-start">
                      {field.value
                        ? format(field.value, "dd/MM/yyyy")
                        : "Chọn ngày"}
                      <CalendarIcon className="ml-auto h-4 w-4 opacity-50" />
                    </Button>
                  </FormControl>
                </PopoverTrigger>
                <PopoverContent className="p-0">
                  <Calendar
                    mode="single"
                    selected={field.value}
                    onSelect={field.onChange}
                    initialFocus
                  />
                </PopoverContent>
              </Popover>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Ngày KT */}
        <FormField
          control={form.control}
          name="ngayKT"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Ngày kết thúc</FormLabel>
              <FormControl>
                <Input
                  type="date"
                  value={field.value ? format(field.value, "yyyy-MM-dd") : ""}
                  onChange={(e) =>
                    field.onChange(
                      e.target.value ? new Date(e.target.value) : undefined
                    )
                  }
                />
              </FormControl>
            </FormItem>
          )}
        />

        {/* Active */}
        <FormField
          control={form.control}
          name="isActive"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Trạng thái</FormLabel>
              <Select
                value={field.value.toString()}
                onValueChange={(v) => field.onChange(v === "true")}
              >
                <FormControl>
                  <SelectTrigger>
                    <SelectValue />
                  </SelectTrigger>
                </FormControl>
                <SelectContent>
                  <SelectItem value="true">Active</SelectItem>
                  <SelectItem value="false">Inactive</SelectItem>
                </SelectContent>
              </Select>
            </FormItem>
          )}
        />

        <DialogFooter>
          <Button type="submit">
            {assignment ? "Cập nhật" : "Tạo phân công"}
          </Button>
        </DialogFooter>
      </form>
    </Form>
  );
};

export default AssignmentForm;
