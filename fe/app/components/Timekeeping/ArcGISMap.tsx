// components/Timekeeping/ArcGISMap.tsx

import React, { useRef, useEffect } from "react";
import type { CheckinLocation } from "~/lib/types";

// Định nghĩa Props cho component
interface ArcGISMapProps {
  locations: CheckinLocation[];
}

const ArcGISMap: React.FC<ArcGISMapProps> = ({ locations }) => {
  const mapDiv = useRef<HTMLDivElement>(null);

  useEffect(() => {
    if (mapDiv.current) {
      // ⚠️ Ghi chú: Để mã này chạy, bạn phải cài đặt và cấu hình thư viện ArcGIS JS API
      // (ví dụ: npm install @arcgis/core) và import các module cần thiết.
      // console.log("Initializing ArcGIS Map with locations:", locations);
      // // GIẢ LẬP LOGIC ARC GIS
      // const initializeMap = async () => {
      //   // Import động ArcGIS modules nếu cần
      //   const [Map, MapView, Graphic] = await Promise.all([
      //       import('@arcgis/core/Map'),
      //       import('@arcgis/core/views/MapView'),
      //       import('@arcgis/core/Graphic')
      //   ]);
      //   const map = new Map.default({ basemap: 'topo-vector' });
      //   const view = new MapView.default({
      //     container: mapDiv.current,
      //     map: map,
      //     center: locations.length > 0 ? [locations[0].lon, locations[0].lat] : [106.66, 10.77],
      //     zoom: 14
      //   });
      //
      //   // Xử lý vẽ các điểm chấm công (locations) lên view
      //   // ... logic để tạo Graphic và thêm vào view.graphics ...
      //
      //   return () => view.destroy(); // Cleanup function
      // };
      // initializeMap();
    }
  }, [locations]);

  return (
    <div className="h-full w-full" ref={mapDiv}>
      <p className="p-4 text-center text-gray-500">
        [Bản đồ ArcGIS sẽ được hiển thị ở đây]
      </p>
    </div>
  );
};

export default ArcGISMap;
