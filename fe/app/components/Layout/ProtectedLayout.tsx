import { Navigate, useLocation } from "react-router";
import { StorageKey } from "~/lib/constants/local-storage";

type ProtectedRouteProps = {
  redirectPath?: string;
  children: React.ReactNode;
};

export const ProtectedRoute = ({ children }: ProtectedRouteProps) => {
  if (typeof window === "undefined") return null;

  const location = useLocation();
  const pathname = location.pathname;

  const loginInfo = localStorage.getItem(StorageKey.LOGIN_INFO);
  const role = localStorage.getItem(StorageKey.ROLE);

  if (!loginInfo) {
    return <Navigate to="/login" replace />;
  }

  if (pathname.startsWith("/admin") && role?.toLowerCase() !== "admin") {
    return <Navigate to="/403" replace />;
  }

  return <>{children}</>;
};
