using QuickGraph;
using RailwayStation.Interfaces;
using System.Drawing;
using QuickGraph.Algorithms;

namespace RailwayStation.Model;

public class Station : IStationScheme
{
    private AdjacencyGraph<IVertex, Edge<IVertex>> _graph = new AdjacencyGraph<IVertex, Edge<IVertex>>();

    public List<IPathSegment> Segments { get; private set; }

    public List<IPath> Paths { get; private set; }

    public List<IPark> Parks { get; private set; }

    public Station(List<IPathSegment> pathSegments, List<IPath> paths, List<IPark> parks)
    {
        Segments = pathSegments;
        Paths = paths;
        Parks = parks;

        BuildSegmentsGraph();
    }

    private void BuildSegmentsGraph()
    {
        foreach (var segment in Segments)
        {
            _graph.AddVertex(segment.Start);
            _graph.AddVertex(segment.End);

            _graph.AddEdge(new Edge<IVertex>(segment.Start, segment.End));
        }
    }

    /// <summary>
    /// Найти кратчайший путь между сегментами
    /// </summary>
    /// <returns></returns>
    public List<IPathSegment> FindShortestPath(IPathSegment startSegment, IPathSegment endSegment) =>
        FindShortestPathSegments(startSegment.Start, endSegment.End);

    /// <summary>
    /// Найти кратчайший путь между вершинами
    /// </summary>
    /// <exception cref="InvalidOperationException"></exception>
    private List<IPathSegment> FindShortestPathSegments(IVertex startPoint, IVertex endPoint)
    {
        var paths = _graph.ShortestPathsDijkstra(edge => DistanceBetweenPoints(edge.Source.Point, edge.Target.Point), startPoint);
        
        paths(endPoint, out var path);

        if (path == null)
            throw new InvalidOperationException("No path found between the specified path segments.");

        var shortestPath = path
            .Select(edge =>
                Segments.FirstOrDefault(seg => seg.Start.Equals(edge.Source) && seg.End.Equals(edge.Target)))
            .ToList();

        return shortestPath;
    }

    private float DistanceBetweenPoints(PointF point1, PointF point2)
    {
        float dx = point2.X - point1.X;
        float dy = point2.Y - point1.Y;

        return (float)Math.Sqrt(dx * dx + dy * dy);
    }
}
