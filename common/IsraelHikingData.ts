﻿module IsraelHiking.Common {
    export class routingType {
        public static hike = "hike"; 
        public static bike = "bike";
        public static fourByFour = "fourByFour";
        public static none = "none";
    }

    export interface MarkerData {
        latlng: L.LatLng;
        title: string;
    }

    export interface RouteSegmentData {
        routePoint: L.LatLng;
        latlngs: L.LatLng[];
    }

    export interface RouteData {
        name: string;
        segments: RouteSegmentData[];
        routingType: string;
    }

    export interface DataContainer {
        routes: RouteData[];
        markers: MarkerData[];
        bounds: L.LatLngBounds;
    }
}