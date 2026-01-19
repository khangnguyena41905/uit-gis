// schemas/employee.schema.ts
import { z } from "zod";

export const createEmployeeSchema = z.object({
  hoTen: z.string().min(2, "Họ tên tối thiểu 2 ký tự"),
  ngaySinh: z.date({
    error: "Vui lòng chọn ngày sinh",
  }),
  sdt: z.string().regex(/^[0-9]{9,11}$/, "Số điện thoại không hợp lệ"),
  email: z.string().email("Email không hợp lệ"),
  phongBanId: z.number().min(1, "Vui lòng chọn phòng ban"),
  roleId: z.number(),
  userName: z.string().min(4, "Username tối thiểu 4 ký tự"),
  password: z.string().min(6, "Mật khẩu tối thiểu 6 ký tự"),
});

export type CreateEmployeeFormValues = z.infer<typeof createEmployeeSchema>;
