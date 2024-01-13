using RailwayStation.Interfaces;

namespace RailwayStation.Model;

public class Path : IPath
{
    public string Name { get; }

    public List<IPathSegment> Segments { get; private set; }

    public IPathSegment StartSegment { get; private set;}

    public IPathSegment EndSegment { get; private set; }

    public Path(string name, List<IPathSegment> segments, IPathSegment start = null, IPathSegment end = null)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException(nameof(name));
        Segments = segments ?? throw new ArgumentNullException(nameof(segments));

        if (segments.Any())
        {
            StartSegment = start ?? segments.First();
            EndSegment = end ?? segments.Last();
        }
        else
        {
            StartSegment = start;
            EndSegment = end;
        }
    }

    public override string ToString() => Name;
}
