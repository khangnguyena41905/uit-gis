import React, { useEffect, useRef } from "react";
import Point from "@arcgis/core/geometry/Point";
import Polygon from "@arcgis/core/geometry/Polygon";
import Graphic from "@arcgis/core/Graphic";
import TextSymbol from "@arcgis/core/symbols/TextSymbol";

export interface MapPoint {
  lon: number;
  lat: number;
  color?: string;
  popup?: {
    title?: string;
    content?: string;
  };
}

export interface MapPolygon {
  id: number;
  name?: string;
  firstPointId?: number;
  rings: number[][][];
}

export interface MapArea {
  center?: [number, number];
  zoom?: number;
}

interface ArcGISMapProps {
  points?: MapPoint[];
  polygons?: MapPolygon[];
  area?: MapArea;
  onPolygonClick?: (polygon: {
    polygonId: number;
    firstPointId: number;
    firstPoint: [number, number];
    points: [number, number][];
  }) => void;
}

const ArcGISMap: React.FC<ArcGISMapProps> = ({
  points = [],
  polygons = [],
  area,
  onPolygonClick,
}) => {
  const mapDiv = useRef<HTMLDivElement>(null);
  const viewRef = useRef<__esri.MapView | null>(null);
  const layerRef = useRef<__esri.GraphicsLayer | null>(null);
  const highlightRef = useRef<__esri.Handle | null>(null);

  /* ================= INIT MAP ================= */
  useEffect(() => {
    let mounted = true;
    let clickHandle: __esri.Handle | null = null;

    const init = async () => {
      if (!mapDiv.current || viewRef.current) return;

      const [Map, MapView, GraphicsLayer] = await Promise.all([
        import("@arcgis/core/Map"),
        import("@arcgis/core/views/MapView"),
        import("@arcgis/core/layers/GraphicsLayer"),
      ]);

      if (!mounted) return;

      const map = new Map.default({ basemap: "topo-vector" });

      const view = new MapView.default({
        container: mapDiv.current,
        map,
        center: area?.center ?? [106.79275610764999, 10.857783206346067],
        zoom: area?.zoom ?? 13,
      });

      const layer = new GraphicsLayer.default();
      map.add(layer);

      viewRef.current = view;
      layerRef.current = layer;

      await view.when();
      const layerView = await view.whenLayerView(layer);

      clickHandle = view.on("click", async (event) => {
        const hit = await view.hitTest(event);

        const result = hit.results.find(
          (r): r is __esri.MapViewGraphicHit =>
            "graphic" in r &&
            r.graphic.layer === layer &&
            r.graphic.geometry?.type === "polygon",
        );

        if (!result) return;

        const graphic = result.graphic;
        const polygon = graphic.geometry as __esri.Polygon;

        /* clear old highlight */
        highlightRef.current?.remove();

        /* highlight immediately */
        highlightRef.current = layerView.highlight(graphic);

        view.goTo(polygon.extent?.expand(1.5), { duration: 600 });

        const ring = polygon.rings[0];

        onPolygonClick?.({
          polygonId: graphic.attributes.id,
          firstPointId: graphic.attributes.firstPointId ?? 0,
          firstPoint: [ring[0][0], ring[0][1]],
          points: ring.map((p) => [p[0], p[1]]),
        });
      });

      drawAll();
    };

    init();

    return () => {
      mounted = false;
      clickHandle?.remove();
      highlightRef.current?.remove();
      viewRef.current?.destroy();
      viewRef.current = null;
      layerRef.current = null;
    };
  }, []);

  /* ================= DRAW ================= */
  const drawAll = () => {
    const layer = layerRef.current;
    if (!layer) return;

    layer.removeAll();
    drawPolygons(layer);
    drawPoints(layer);
  };

  const drawPolygons = (layer: __esri.GraphicsLayer) => {
    polygons.forEach((p) => {
      const polygon = new Polygon({
        rings: p.rings,
        spatialReference: { wkid: 4326 },
      });

      const graphic = new Graphic({
        geometry: polygon,
        attributes: { id: p.id, name: p.name, firstPointId: p.firstPointId },
        symbol: {
          type: "simple-fill",
          color: [66, 199, 190, 0.35],
          outline: { color: "#ffffff", width: 1 },
        },
      });

      layer.add(graphic);

      /* -------- Label ở giữa polygon -------- */
      if (p.name && polygon.centroid) {
        layer.add(
          new Graphic({
            geometry: polygon.centroid,
            symbol: new TextSymbol({
              text: p.name,
              color: "#0f172a",
              font: { size: 9, weight: "bold" },
              haloColor: "#ffffff",
              haloSize: 2,
            }),
          }),
        );
      }
    });
  };

  const drawPoints = (gl: any) => {
    points.forEach((p) => {
      gl.add(
        new Graphic({
          geometry: new Point({
            x: p.lon,
            y: p.lat,
            spatialReference: { wkid: 4326 },
          }),
          symbol: {
            type: "simple-marker",
            style: "circle",
            color: p.color ?? "#e53935",
            size: "10px",
            outline: { color: "#fff", width: 1 },
          },
          popupTemplate: p.popup,
        }),
      );
    });
  };

  /* ================= UPDATE ================= */
  useEffect(() => {
    drawAll();
  }, [points, polygons]);

  return (
    <div
      ref={mapDiv}
      tabIndex={0}
      className="w-full h-full rounded-lg border overflow-hidden"
    />
  );
};

export default ArcGISMap;
