namespace RailwayStation.Interfaces;

public interface IStationScheme
{
    List<IPathSegment> Segments { get; }
    List<IPath> Paths { get; }
    List<IPark> Parks { get; }

    List<IPathSegment> FindShortestPath(IPathSegment startSegment, IPathSegment endSegment);
}
