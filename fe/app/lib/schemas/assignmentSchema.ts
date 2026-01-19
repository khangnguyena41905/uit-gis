import { z } from "zod";

export const assignmentSchema = z.object({
  caId: z.number().min(1, "Vui lòng chọn ca làm"),
  nhanVienId: z.number().min(1, "Vui lòng chọn nhân viên"),
  diaDiemId: z.number().min(1, "Vui lòng chọn địa điểm"),
  ngayBD: z.date(),
  ngayKT: z.date().optional(),
  isActive: z.boolean(),
});

export type AssignmentFormValues = z.infer<typeof assignmentSchema>;
