﻿using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using IsraelHiking.API.Gpx;
using NetTopologySuite.IO;

namespace IsraelHiking.API.Converters.ConverterFlows
{
    ///<inheritdoc />
    public class GpxToRouteGpxConverterFlow : IConverterFlowItem
    {
        ///<inheritdoc />
        public string Input => FlowFormats.GPX_BABEL_FORMAT;
        ///<inheritdoc />
        public string Output => FlowFormats.GPX_ROUTE;

        ///<inheritdoc />
        public byte[] Transform(byte[] content)
        {
            var gpx = content.ToGpx();
            var routes = gpx.Routes ?? new List<GpxRoute>();
            routes.AddRange((gpx.Tracks ?? new List<GpxTrack>()).Select(t => new GpxRoute(
                name: t.Name,
                description: t.Description,
                comment: t.Comment,
                waypoints: new ImmutableGpxWaypointTable(t.Segments.SelectMany(s => s.Waypoints)),
                source: null, links: ImmutableArray<GpxWebLink>.Empty, number: null, classification: null, extensions: null
            )));
            var routeGpx = new GpxMainObject
            {
                Waypoints = gpx.Waypoints,
                Routes = routes.ToList(),
                Tracks = new List<GpxTrack>(),
            };
            return routeGpx.ToBytes();
        }
    }
}