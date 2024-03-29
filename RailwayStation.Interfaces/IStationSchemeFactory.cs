﻿using System.Drawing;

namespace RailwayStation.Interfaces;

public interface IStationSchemeFactory
{
    IVertex CreateVertex(PointF point);
    IPathSegment CreatePathSegment(string name, int number, IVertex startPoint, IVertex endPoint);
    IPath CreatePath(string name, List<IPathSegment> segments, IPathSegment start, IPathSegment end);
    IPark CreatePark(string name, List<IPath> paths);
    IStationScheme CreateStation(List<IPathSegment> pathSegments, List<IPath> paths, List<IPark> parks);
}
