import { useForm } from "react-hook-form";
import { zodResolver } from "@hookform/resolvers/zod";

import { shiftSchema, type ShiftFormValues } from "~/lib/schemas/shiftSchema";

import { Button } from "@/components/ui/button";
import { Input } from "@/components/ui/input";
import {
  Form,
  FormControl,
  FormField,
  FormItem,
  FormLabel,
  FormMessage,
} from "@/components/ui/form";
import {
  Select,
  SelectContent,
  SelectItem,
  SelectTrigger,
  SelectValue,
} from "@/components/ui/select";
import { DialogFooter } from "@/components/ui/dialog";

import type { IShift } from "~/lib/interfaces/shift.interface";

interface ShiftFormProps {
  shift: IShift | null;
  onSubmit: (data: ShiftFormValues) => void;
}

export const ShiftForm: React.FC<ShiftFormProps> = ({ shift, onSubmit }) => {
  const form = useForm<ShiftFormValues>({
    resolver: zodResolver(shiftSchema),
    defaultValues: {
      maCa: shift?.maCa ?? "",
      tenCa: shift?.tenCa ?? "",
      gioBD: shift?.gioBD ?? "",
      gioKT: shift?.gioKT ?? "",
      isActive: shift?.isActive ?? true,
    },
  });

  const handleSubmit = (values: ShiftFormValues) => {
    onSubmit(values);
  };

  return (
    <Form {...form}>
      <form onSubmit={form.handleSubmit(handleSubmit)} className="space-y-4">
        {/* Mã ca */}
        <FormField
          control={form.control}
          name="maCa"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Mã ca</FormLabel>
              <FormControl>
                <Input placeholder="CA_SANG" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Tên ca */}
        <FormField
          control={form.control}
          name="tenCa"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Tên ca</FormLabel>
              <FormControl>
                <Input placeholder="Ca sáng" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Giờ bắt đầu */}
        <FormField
          control={form.control}
          name="gioBD"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Giờ bắt đầu</FormLabel>
              <FormControl>
                <Input type="time" {...field} />
              </FormControl>
              <FormMessage />
            </FormItem>
          )}
        />

        {/* Giờ kết thúc */}
        <FormField
          control={form.control}
          name="gioKT"
          render={({ field }) => (
            <FormItem>
              <FormLabel>Giờ kết thúc</FormLabel>
              <FormControl>
                <Input type="time" {...field} />
              </FormControl>
              <FormMessage />
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
          <Button type="submit">{shift ? "Cập nhật" : "Tạo ca làm"}</Button>
        </DialogFooter>
      </form>
    </Form>
  );
};
