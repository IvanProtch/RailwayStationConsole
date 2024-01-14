namespace RailwayStation.Interfaces;

public interface IStationScheme
{
    List<IPathSegment> Segments { get; }
    List<IPath> Paths { get; }
    List<IPark> Parks { get; }

    /// <summary>
    /// Найти кратчайший путь между сегментами
    /// </summary>
    /// <returns></returns>
    List<IPathSegment> FindShortestPath(IPathSegment startSegment, IPathSegment endSegment);
}
