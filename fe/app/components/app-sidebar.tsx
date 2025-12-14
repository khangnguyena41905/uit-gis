"use client";

import * as React from "react";
import { AudioWaveform, Command, GalleryVerticalEnd } from "lucide-react";

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
const generateNavMainFromRoutes = (routePaths: RoutePath[]) => {
  return routePaths
    .filter((route) => route.id === "layout")[0]
    .children!.filter(
      (route) =>
        route.isShowInMenu ||
        route.children?.some((child) => child.isShowInMenu)
    )
    .map((route) => {
      return {
        title: route.name,
        url: route.path,
        isActive: false,
        icon: route.icon,
        items: !route.children
          ? undefined
          : route.children
              .filter((childRoute) => childRoute.isShowInMenu)
              .map((childRoute) => {
                return {
                  title: childRoute.name,
                  url: childRoute.path,
                };
              }),
      };
    });
};
// This is sample data.
const data = {
  user: {
    name: "shadcn",
    email: "m@example.com",
    avatar: "/avatars/shadcn.jpg",
  },
  teams: [
    {
      name: "Acme Inc",
      logo: GalleryVerticalEnd,
      plan: "Enterprise",
    },
    {
      name: "Acme Corp.",
      logo: AudioWaveform,
      plan: "Startup",
    },
    {
      name: "Evil Corp.",
      logo: Command,
      plan: "Free",
    },
  ],
  navMain: [...generateNavMainFromRoutes(ROUTE_PATHS)],
};

export function AppSidebar({ ...props }: React.ComponentProps<typeof Sidebar>) {
  return (
    <Sidebar collapsible="icon" {...props}>
      <SidebarHeader>
        <TeamSwitcher teams={data.teams} />
      </SidebarHeader>
      <SidebarContent>
        <NavMain items={data.navMain} />
      </SidebarContent>
      <SidebarFooter>
        <NavUser user={data.user} />
      </SidebarFooter>
      <SidebarRail />
    </Sidebar>
  );
}
