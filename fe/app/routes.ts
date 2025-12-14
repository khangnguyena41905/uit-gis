import {
  type RouteConfig,
  route,
  type RouteConfigEntry,
} from "@react-router/dev/routes";
import { ROUTE_PATHS, type RoutePath } from "./lib/route-path";

// export default [
//   route("login", "./pages/Auth/LoginPage.tsx"),

//   route("/", "./components/Layout/Layout.tsx", [
//     route("employee", "./pages/Employee/EmployeeManagementPage.tsx"),
//     route("assignment", "./pages/Assignment/AssignmentPage.tsx"),
//     route("timekeeping", "./pages/Timekeeping/TimekeepingManagementPage.tsx", [
//       route(":id", "./pages/Timekeeping/TimekeepingDetailPage.tsx"),
//     ]),
//   ]),

//   route("*", "./pages/NotFoundPage.tsx"),
// ] satisfies RouteConfig;

const generatedRoutes = (routePaths: RoutePath[]): RouteConfigEntry[] => {
  return routePaths.map((routePath) => {
    if (routePath.children && routePath.children.length > 0) {
      return route(
        routePath.path,
        routePath.fileLocation,
        generatedRoutes(routePath.children)
      );
    } else {
      return route(routePath.id, routePath.fileLocation);
    }
  });
};

export default [...generatedRoutes(ROUTE_PATHS)] satisfies RouteConfig;
