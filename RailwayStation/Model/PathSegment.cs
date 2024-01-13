using RailwayStation.Interfaces;

namespace RailwayStation.Model;

public class PathSegment : IPathSegment
{
    public int Number { get; }
    public string Name { get; }
    public IVertex Start { get; }
    public IVertex End { get; }

    public PathSegment(string name, int number, IVertex startPoint, IVertex endPoint)
    {
        Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentException(nameof(name));
        Number = number;
        End = endPoint ?? throw new ArgumentNullException(nameof(endPoint));
        Start = startPoint ?? throw new ArgumentNullException(nameof(startPoint));
    }

    public override string ToString() => $"{Number}.{Name}";
}
