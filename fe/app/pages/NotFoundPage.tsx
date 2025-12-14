// src/pages/NotFoundPage.tsx

import React from "react";
import { Link } from "react-router";

const NotFoundPage: React.FC = () => {
  return (
    <div className="min-h-screen flex flex-col items-center justify-center bg-gray-50 text-center p-4">
      <h1 className="text-9xl font-extrabold text-indigo-600 tracking-widest">
        404
      </h1>
      <div className="bg-red-600 px-2 text-sm rounded rotate-12 absolute text-white">
        Không tìm thấy trang
      </div>
      <p className="mt-5 text-xl font-medium text-gray-700">
        Xin lỗi, đường dẫn bạn yêu cầu không tồn tại.
      </p>
      <Link
        to="/"
        className="mt-8 px-6 py-3 text-sm font-semibold text-white bg-indigo-600 rounded-lg hover:bg-indigo-700 transition duration-150 shadow-lg"
      >
        Quay về Trang chủ
      </Link>
    </div>
  );
};

export default NotFoundPage;
