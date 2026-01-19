import { z } from "zod";

export const shiftSchema = z.object({
  maCa: z.string().min(1, "Vui lòng nhập mã ca"),
  tenCa: z.string().min(1, "Vui lòng nhập tên ca"),
  gioBD: z.string().min(1, "Vui lòng chọn giờ bắt đầu"),
  gioKT: z.string().min(1, "Vui lòng chọn giờ kết thúc"),
  isActive: z.boolean(),
});

export type ShiftFormValues = z.infer<typeof shiftSchema>;
