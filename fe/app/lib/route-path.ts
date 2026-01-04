import {
  ClipboardList,
  FingerprintPattern,
  Users,
  type LucideIcon,
} from "lucide-react";

export interface RoutePath {
  id: string;
  name: string;
  path: string;
  fileLocation: string;
  isShowInMenu: boolean;
  icon?: LucideIcon;
  children?: RoutePath[];
  middlewares?: any[];
}

export const ROUTE_PATHS: RoutePath[] = [
  {
    id: "login",
    name: "Login",
    path: "/login",
    fileLocation: "./pages/Auth/LoginPage.tsx",
    isShowInMenu: false,
  },
  {
    id: "layout",
    name: "Application Layout",
    path: "/",
    fileLocation: "./components/Layout/Layout.tsx",
    isShowInMenu: false,
    children: [
      {
        id: "employee",
        name: "Quản lý nhân sự",
        path: "/employee",
        fileLocation: "./pages/Employee/EmployeeManagementPage.tsx",
        isShowInMenu: true,
        icon: Users,
      },
      {
        id: "assignment",
        name: "Phân ca",
        path: "/assignment",
        fileLocation: "./pages/Assignment/AssignmentPage.tsx",
        isShowInMenu: true,
        icon: ClipboardList,
      },
      {
        id: "timekeeping",
        name: "Quản lý Chấm công",
        path: "/timekeeping",
        fileLocation: "./pages/Timekeeping/TimekeepingManagementPage.tsx",
        isShowInMenu: true,
        icon: FingerprintPattern,
        // children: [
        //   {
        //     id: "timekeeping-detail",
        //     name: "Chi tiết Chấm công",
        //     path: ":id",
        //     fileLocation: "./pages/Timekeeping/TimekeepingDetailPage.tsx",
        //     isShowInMenu: false,
        //   },
        // ],
      },
      {
        id: "timekeeping-detail",
        name: "Chi tiết Chấm công",
        path: "/timekeeping/:id",
        fileLocation: "./pages/Timekeeping/TimekeepingDetailPage.tsx",
        isShowInMenu: false,
      },
    ],
  },

  {
    id: "not-found",
    name: "404 Not Found",
    path: "*",
    fileLocation: "./pages/NotFoundPage.tsx",
    isShowInMenu: false,
  },
];
