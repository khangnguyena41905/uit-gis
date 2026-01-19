// src/pages/Assignment/AssignmentPage.tsx

import React from "react";
import { Tabs, TabsContent, TabsList, TabsTrigger } from "@/components/ui/tabs";
import ShiftTab from "./components/ShiftTab";
import AssignmentTab from "./components/AssignmentTab";

const AssignmentPage: React.FC = () => {
  return (
    <div className="space-y-8">
      <h1 className="text-3xl font-bold text-gray-800">
        📅 Phân công Ca làm việc
      </h1>

      <Tabs defaultValue="shifts" className="w-full">
        <TabsList className="grid w-full grid-cols-2">
          <TabsTrigger value="shifts">Định nghĩa Ca làm & Khu vực</TabsTrigger>
          <TabsTrigger value="assignments">Phân công cho Nhân viên</TabsTrigger>
        </TabsList>
        <TabsContent value="shifts">
          <ShiftTab />
        </TabsContent>
        <TabsContent value="assignments">
          <AssignmentTab />
        </TabsContent>
      </Tabs>
    </div>
  );
};

export default AssignmentPage;
