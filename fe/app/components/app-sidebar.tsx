import * as React from "react";
import { GalleryVerticalEnd } from "lucide-react";

import { NavMain } from "~/components/nav-main";
import { NavUser } from "~/components/nav-user";
import { TeamSwitcher } from "~/components/team-switcher";
import {
  Sidebar,
  SidebarContent,
  SidebarFooter,
  SidebarHeader,
  SidebarRail,
} from "~/components/ui/sidebar";

import { ROUTE_PATHS, type RoutePath } from "~/lib/route-path";
import { useMetadataStore } from "~/lib/stores/useMetadataStore";
import { StorageKey } from "~/lib/constants/local-storage";

/* ================================
   Helpers
================================ */

const generateNavMainFromRoutes = (
  routePaths: RoutePath[],
  role: string | null,
) => {
  const layout = routePaths.find((r) => r.id === "layout");
  if (!layout?.children) return [];

  return layout.children
    .filter((route) => {
      if (!route.isShowInMenu) return false;

      if (role !== "admin" && route.path.startsWith("/admin")) {
        return false;
      }

      return true;
    })
    .map((route) => ({
      title: route.name,
      url: route.path,
      isActive: false,
      icon: route.icon,
    }));
};

export function AppSidebar({ ...props }: React.ComponentProps<typeof Sidebar>) {
  const employee = useMetadataStore((s) => s.employee);

  const [navMain, setNavMain] = React.useState<any[]>([]);

  React.useEffect(() => {
    const role = localStorage.getItem(StorageKey.ROLE);
    const menu = generateNavMainFromRoutes(
      ROUTE_PATHS,
      role?.toLowerCase() ?? "",
    );
    setNavMain(menu);
  }, []);

  return (
    <Sidebar collapsible="icon" {...props}>
      <SidebarHeader>
        <TeamSwitcher
          teams={[
            {
              name: "UIT GIS",
              logo: GalleryVerticalEnd,
              plan: "Enterprise",
            },
          ]}
        />
      </SidebarHeader>

      <SidebarContent>
        <NavMain items={navMain} />
      </SidebarContent>

      <SidebarFooter>
        <NavUser
          user={{
            name: employee?.hoTen ?? "Unknown User",
            email: employee?.email ?? "",
            avatar: "/avatar-default.png",
          }}
        />
      </SidebarFooter>

      <SidebarRail />
    </Sidebar>
  );
}
