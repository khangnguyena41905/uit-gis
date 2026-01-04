// components/Timekeeping/ArcGISMap.tsx

import Point from "@arcgis/core/geometry/Point";
import Polygon from "@arcgis/core/geometry/Polygon";
import Graphic from "@arcgis/core/Graphic";
import React, { useRef, useEffect } from "react";
import type { CheckinLocation } from "~/lib/types";

// Định nghĩa Props cho component
// Note: ensure `@arcgis/core` is installed in your project (npm install @arcgis/core)
// and add the esri theme css in your global stylesheet or import below if desired:
// import '@arcgis/core/assets/esri/themes/light/main.css';

interface ArcGISMapProps {
  locations: CheckinLocation[];
  polygons?: { id: number; name?: string; rings: number[][][] }[];
}

const ArcGISMap: React.FC<ArcGISMapProps> = ({ locations, polygons }) => {
  const mapDiv = useRef<HTMLDivElement>(null);
  const viewRef = useRef<any>(null);
  const graphicsLayerRef = useRef<any>(null);

  useEffect(() => {
    let mounted = true;

    const initialize = async () => {
      if (!mapDiv.current) return;

      try {
        const [
          MapModule,
          MapViewModule,
          // GraphicModule,
          // PolygonModule,
          // PointModule,
          GraphicsLayerModule,
        ] = await Promise.all([
          import("@arcgis/core/Map"),
          import("@arcgis/core/views/MapView"),
          // import("@arcgis/core/Graphic"),
          // import("@arcgis/core/geometry/Polygon"),
          // import("@arcgis/core/geometry/Point"),
          import("@arcgis/core/layers/GraphicsLayer"),
        ]);

        const Map = MapModule.default;
        const MapView = MapViewModule.default;
        // const Graphic = GraphicModule.default;
        // const Polygon = PolygonModule.default;
        // const Point = PointModule.default;
        const GraphicsLayer = GraphicsLayerModule.default;

        // create map & view only once
        if (!viewRef.current && mounted) {
          const map = new Map({ basemap: "topo-vector" });
          const view = new MapView({
            container: mapDiv.current as HTMLDivElement,
            map,
            center:
              locations.length > 0
                ? [locations[0].lon, locations[0].lat]
                : [106.66, 10.77],
            zoom: 14,
          });

          const graphicsLayer = new GraphicsLayer();
          map.add(graphicsLayer);

          viewRef.current = view;
          graphicsLayerRef.current = graphicsLayer;

          // Wait for view to be ready
          await view.when();
        }

        // draw initial features
        drawFeatures();
      } catch (err) {
        // If import fails, keep placeholder and notify
        // eslint-disable-next-line no-console
        console.warn(
          "ArcGIS modules not available. Install @arcgis/core to enable map.",
          err
        );
      }
    };

    const clearGraphics = () => {
      const gl = graphicsLayerRef.current;
      if (gl && gl.removeAll) {
        gl.removeAll();
      }
    };

    const drawFeatures = () => {
      const gl = graphicsLayerRef.current;
      const view = viewRef.current;
      if (!gl || !view) return;

      clearGraphics();

      // Polygons
      polygons?.forEach((poly) => {
        try {
          // // @ts-ignore
          // const Polygon = require("@arcgis/core/geometry/Polygon")
          //   .default as any;
          // // @ts-ignore
          // const Graphic = require("@arcgis/core/Graphic").default as any;
          const geom = new Polygon({ rings: poly.rings });
          const graphic = new Graphic({
            geometry: geom,
            symbol: {
              type: "simple-fill",
              color: [51, 51, 204, 0.15],
              outline: { color: [51, 51, 204], width: 1 },
            },
            attributes: { name: poly.name },
            popupTemplate: { title: poly.name ?? "Khu vực" },
          });
          gl.add(graphic);
        } catch (e) {
          // ignore
        }
      });

      // Points (checkins)
      locations.forEach((loc) => {
        try {
          // @ts-ignore
          // const Point = require("@arcgis/core/geometry/Point").default as any;
          // // @ts-ignore
          // const Graphic = require("@arcgis/core/Graphic").default as any;

          const pt = new Point({
            x: loc.lon,
            y: loc.lat,
            spatialReference: { wkid: 4326 },
          });
          const graphic = new Graphic({
            geometry: pt,
            symbol: {
              type: "simple-marker",
              style: "circle",
              color: "#e53935",
              size: "10px",
              outline: { color: "white", width: 1 },
            },
            attributes: {
              time: loc.time,
              note: (loc as any).note ?? (loc as any).type ?? "",
            },
            popupTemplate: {
              title: "Chấm công",
              content: "<b>Thời gian:</b> {time} <br/><b>Ghi chú:</b> {note}",
            },
          });

          gl.add(graphic);
        } catch (e) {
          // ignore
        }
      });

      // Focus the view
      if (locations.length > 0 && view && view.goTo) {
        view.goTo({ center: [locations[0].lon, locations[0].lat], zoom: 14 });
      } else if (polygons && polygons.length > 0 && view && view.goTo) {
        // center on first polygon centroid (approx using first ring's first point)
        const firstRing = polygons[0].rings?.[0];
        if (firstRing && firstRing.length > 0) {
          const [x, y] = firstRing[0];
          view.goTo({ center: [x, y] as any, zoom: 13 });
        }
      }
    };

    initialize();

    return () => {
      mounted = false;
      // destroy view
      if (viewRef.current && viewRef.current.destroy) {
        try {
          viewRef.current.destroy();
        } catch (e) {
          // ignore
        }
        viewRef.current = null;
      }
      graphicsLayerRef.current = null;
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  // update graphics when locations or polygons change
  useEffect(() => {
    try {
      // if view and layer exist, redraw
      if (viewRef.current && graphicsLayerRef.current) {
        // drawFeatures is closed over in the other effect; call by re-initializing the layer content here
        // simplest is to remove all and add updated features similar to initial draw
        const gl = graphicsLayerRef.current;
        if (gl && gl.removeAll) gl.removeAll();

        // Add polygons
        polygons?.forEach((poly) => {
          try {
            // @ts-ignore
            // const Polygon = require("@arcgis/core/geometry/Polygon")
            //   .default as any;
            // @ts-ignore
            // const Graphic = require("@arcgis/core/Graphic").default as any;
            const geom = new Polygon({ rings: poly.rings });
            const graphic = new Graphic({
              geometry: geom,
              symbol: {
                type: "simple-fill",
                color: [51, 51, 204, 0.15],
                outline: { color: [51, 51, 204], width: 1 },
              },
              attributes: { name: poly.name },
              popupTemplate: { title: poly.name ?? "Khu vực" },
            });
            gl.add(graphic);
          } catch (e) {}
        });

        // Add points
        locations.forEach((loc) => {
          try {
            // @ts-ignore
            // const Point = require("@arcgis/core/geometry/Point").default as any;
            // @ts-ignore
            // const Graphic = require("@arcgis/core/Graphic").default as any;
            const pt = new Point({
              x: loc.lon,
              y: loc.lat,
              spatialReference: { wkid: 4326 },
            });
            const graphic = new Graphic({
              geometry: pt,
              symbol: {
                type: "simple-marker",
                style: "circle",
                color: "#e53935",
                size: "10px",
                outline: { color: "white", width: 1 },
              },
              attributes: {
                time: loc.time,
                note: (loc as any).note ?? (loc as any).type ?? "",
              },
              popupTemplate: {
                title: "Chấm công",
                content: "<b>Thời gian:</b> {time} <br/><b>Ghi chú:</b> {note}",
              },
            });
            gl.add(graphic);
          } catch (e) {}
        });

        // fit to data
        const view = viewRef.current;
        if (locations.length > 0 && view) {
          view.goTo({ center: [locations[0].lon, locations[0].lat], zoom: 14 });
        }
      }
    } catch (e) {
      // ignore
    }
  }, [locations, polygons]);

  return (
    <div className="h-full w-full" ref={mapDiv}>
      <div className="p-4 text-center text-gray-500">
        {!viewRef.current ? (
          <p>
            [Bản đồ ArcGIS sẽ được khởi tạo ở đây — hãy cài đặt @arcgis/core]
          </p>
        ) : null}
      </div>
    </div>
  );
};

export default ArcGISMap;
