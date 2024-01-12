using RailwayStation.Interfaces;

namespace RailwayStation.Model;

public class PathSegment : IPathSegment, IEquatable<PathSegment>
{
    public int Number { get; private set; }

    public string Name { get; private set; }

    public IVertex Start { get; private set; }

    public IVertex End { get; private set; }

    public PathSegment(string name, int number, IVertex startPoint, IVertex endPoint)
    {
        Name = name;
        Number = number;
        End = endPoint;
        Start = startPoint;
    }

    public override string ToString() => $"{Number}.{Name}";

    public bool Equals(PathSegment? other)
    {
        return other != null && other.Number == Number && other.Name == Name;
    }
}
