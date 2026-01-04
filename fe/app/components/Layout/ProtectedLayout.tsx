import { Navigate } from "react-router";
import { StorageKey } from "~/lib/constants/local-storage";

type ProtectedRouteProps = {
  redirectPath?: string;
  children: React.ReactNode;
};

export const ProtectedRoute = ({ children }: ProtectedRouteProps) => {
  if (typeof window === "undefined") return null;

  const token = localStorage.getItem(StorageKey.LOGIN_INFO);

  if (!token) {
    return <Navigate to="/login" replace />;
  }

  return <>{children}</>;
};
