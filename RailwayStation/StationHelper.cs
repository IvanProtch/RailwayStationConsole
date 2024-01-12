using RailwayStation.Interfaces;
using RailwayStation.Model;
using System.Drawing;
using Path = RailwayStation.Model.Path;

namespace RailwayStation
{
    public static class StationHelper
    {
        //Все данные станции захардкодены
        public static IStationScheme CreateStation()
        {
            List<IPathSegment> segments = new List<IPathSegment>();
            List<IPath> paths = new List<IPath>();
            List<IPark> parks = new List<IPark>();  

            var pointA = new Vertex(new Point(0, 0));
            var pointB = new Vertex(new Point(0, 5));
            var pointC = new Vertex(new Point(2, 10));
            var pointD = new Vertex(new Point(5, 15));

            var pointE = new Vertex(new Point(0, 3));
            var pointF = new Vertex(new Point(1, 5));
            var pointG = new Vertex(new Point(2, 10));

            var pointH = new Vertex(new Point(1, 10));
            var pointI = new Vertex(new Point(5, 10));

            IPathSegment segmentAB = new PathSegment("segmentAB", 1, pointA, pointB);
            IPathSegment segmentBC = new PathSegment("segmentBC", 2, pointB, pointC);
            IPathSegment segmentCD = new PathSegment("segmentCD", 3, pointC, pointD);

            IPathSegment segmentEF = new PathSegment("segmentEF", 4, pointE, pointF);
            IPathSegment segmentFG = new PathSegment("segmentFG", 5, pointF, pointG);
            IPathSegment segmentHI = new PathSegment("segmentFG", 5, pointH, pointI);

            segments.Add(segmentAB);
            segments.Add(segmentBC);
            segments.Add(segmentCD);
            segments.Add(segmentEF);
            segments.Add(segmentFG);
            segments.Add(segmentHI);

            IPath path1 = new Path("Path 1", new List<IPathSegment> { segmentAB, segmentBC, segmentCD }, segmentAB, segmentCD);
            IPath path2 = new Path("Path 2", new List<IPathSegment> { segmentEF, segmentFG }, segmentEF, segmentFG);
            IPath path3 = new Path("Path 3", new List<IPathSegment> { segmentHI }, segmentHI, segmentHI);

            paths.Add(path1);
            paths.Add(path2);
            paths.Add(path3);

            Park park1 = new Park("Park 1", new List<IPath> { path1, path2 });
            Park park2 = new Park("Park 2", new List<IPath> { path3 });

            parks.Add(park1);
            parks.Add(park2);

            return new Station(segments, paths, parks);
        }
    }
}