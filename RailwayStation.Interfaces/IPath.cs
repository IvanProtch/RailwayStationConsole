namespace RailwayStation.Interfaces
{
    public interface IPath
    {
        List<IPathSegment> Segments { get; }
        IPathSegment StartSegment { get; }
        IPathSegment EndSegment { get; }
    }
}
