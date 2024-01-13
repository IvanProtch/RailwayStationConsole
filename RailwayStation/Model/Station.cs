using QuickGraph;
using RailwayStation.Interfaces;
using System.Drawing;
using QuickGraph.Algorithms;

namespace RailwayStation.Model;

public class Station : IStationScheme
{
    private AdjacencyGraph<IVertex, Edge<IVertex>> _graph = new AdjacencyGraph<IVertex, Edge<IVertex>>();
    private Dictionary<(IVertex, IVertex), IPathSegment> _segmentsDictionary;

    public List<IPathSegment> Segments { get; private set; }
    public List<IPath> Paths { get; private set; }
    public List<IPark> Parks { get; private set; }

    public Station(List<IPathSegment> pathSegments, List<IPath> paths, List<IPark> parks)
    {
        Segments = pathSegments ?? throw new ArgumentNullException(nameof(pathSegments));
        Paths = paths ?? throw new ArgumentNullException(nameof(paths));
        Parks = parks ?? throw new ArgumentNullException(nameof(parks));

        Initialize();
    }

    private void Initialize()
    {
        _graph = new AdjacencyGraph<IVertex, Edge<IVertex>>();
        _segmentsDictionary = new Dictionary<(IVertex, IVertex), IPathSegment>();

        InitSegmentsGraph();
        InitSegmentDictionary();
    }

    private void InitSegmentsGraph()
    {
        foreach (var segment in Segments)
        {
            _graph.AddVertex(segment.Start);
            _graph.AddVertex(segment.End);

            _graph.AddEdge(new Edge<IVertex>(segment.Start, segment.End));
        }
    }

    private void InitSegmentDictionary() => _segmentsDictionary = Segments.ToDictionary(segment => (segment.Start, segment.End));

    /// <summary>
    /// Найти кратчайший путь между сегментами
    /// </summary>
    /// <returns></returns>
    public List<IPathSegment> FindShortestPath(IPathSegment startSegment, IPathSegment endSegment)
    {
        var startPoint = startSegment.Start;
        var endPoint = endSegment.End;

        if (!_graph.ContainsVertex(startPoint) || !_graph.ContainsVertex(endPoint))
            throw new InvalidOperationException("Начальная или конечная точка не найдена в графе.");

        var paths = _graph.ShortestPathsDijkstra(edge => DistanceBetweenPoints(edge.Source.Point, edge.Target.Point), startPoint);

        paths(endPoint, out var graphShortedPath);

        if (graphShortedPath == null || graphShortedPath.Count() == 0)
            throw new InvalidOperationException($"Путь между участками {startSegment} и {endSegment} не найден.");

        var shortestPathBetweenSegments = graphShortedPath
            .Select(edge => _segmentsDictionary[(edge.Source, edge.Target)])
            .ToList();

        return shortestPathBetweenSegments;
    }

    private float DistanceBetweenPoints(PointF point1, PointF point2)
    {
        float dx = point2.X - point1.X;
        float dy = point2.Y - point1.Y;

        return (float)Math.Sqrt(dx * dx + dy * dy);
    }
}
