import {
  type RouteConfig,
  route,
  type RouteConfigEntry,
} from "@react-router/dev/routes";
import { ROUTE_PATHS, type RoutePath } from "./lib/route-path";

const generatedRoutes = (
  routePaths: RoutePath[],
  parentPath = "",
): RouteConfigEntry[] => {
  return routePaths.map((routePath) => {
    const currentPath = `${parentPath}/${routePath.path}`.replace(/\/+/g, "/");

    if (routePath.children && routePath.children.length > 0) {
      return route(
        currentPath,
        routePath.fileLocation,
        generatedRoutes(routePath.children, currentPath),
      );
    }

    return route(currentPath, routePath.fileLocation);
  });
};

export default [...generatedRoutes(ROUTE_PATHS)] satisfies RouteConfig;
