// pages/Auth/LoginPage.tsx

import React, { useState, type FormEvent } from "react";
import { useNavigate } from "react-router";
import { toast } from "sonner";
import { StorageKey } from "~/lib/constants/local-storage";
import { unitOfWork } from "~/lib/services/abstractions/unit-of-work";
import { useMetadataStore } from "~/lib/stores/useMetadataStore";

const LoginPage: React.FC = () => {
  const { setDepartments } = useMetadataStore.getState();

  const [username, setUsername] = useState<string>("");
  const [password, setPassword] = useState<string>("");
  const navigate = useNavigate();

  const fetchMetadata = async (userId: number) => {
    const { setDepartments, setEmployee } = useMetadataStore.getState();

    const deptRes = await unitOfWork.departmentService.getPagedDepartments({
      pageIndex: 1,
      pageSize: 1000,
    });

    setDepartments(deptRes?.items ?? []);

    const emp = await unitOfWork.employeeService.getById(userId.toString());

    setEmployee(emp);
  };
  const handleLogin = async (e: React.FormEvent) => {
    e.preventDefault();

    try {
      const res = await unitOfWork.authService.login(username, password);

      if (res) {
        localStorage.setItem(StorageKey.LOGIN_INFO, JSON.stringify(res));
        await fetchMetadata(res.nhanVienId);
        toast.success("Đăng nhập thành công");

        navigate("/timekeeping");
      } else {
        toast.error("Sai tên đăng nhập hoặc mật khẩu");
      }
    } catch (error) {
      toast.error("Có lỗi xảy ra, vui lòng thử lại");
      console.error(error);
    }
  };

  return (
    <div className="min-h-screen flex items-center justify-center bg-gray-50">
      <div className="max-w-md w-full p-8 space-y-8 bg-white shadow-lg rounded-lg">
        <h2 className="text-3xl font-bold text-center text-indigo-600">
          Đăng nhập
        </h2>
        <form className="mt-8 space-y-6" onSubmit={handleLogin}>
          <label htmlFor="username" className="text-indigo-500 font-medium">
            Tên đăng nhập
          </label>
          <input
            type="username"
            placeholder="Tên đăng nhập..."
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            className="w-full px-4 py-2 border rounded-md border-indigo-500 placeholder-gray-400 text-gray-500"
            required
          />
          <label htmlFor="password" className="text-indigo-500 font-medium">
            Mật khẩu
          </label>
          <input
            type="password"
            placeholder="Mật khẩu..."
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            className="w-full px-4 py-2 border rounded-md border-indigo-500 placeholder-gray-400 text-gray-500"
            required
          />
          <button
            type="submit"
            className="w-full py-2 bg-indigo-600 text-white font-semibold rounded-md hover:bg-indigo-700"
          >
            Đăng nhập
          </button>
        </form>
      </div>
    </div>
  );
};

export default LoginPage;
