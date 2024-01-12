using RailwayStation.Interfaces;
using System.Drawing;

namespace RailwayStation.Model;

public class Vertex : IVertex, IComparable<IVertex>, IEquatable<Vertex>
{
    public PointF Point { get; }

    public Vertex(PointF point)
    {
        Point = point;
    }

    public int CompareTo(IVertex other)
    {
        if (Point.X.CompareTo(other.Point.X) != 0)
            return Point.X.CompareTo(other.Point.X);
        else
            return Point.Y.CompareTo(other.Point.Y);
    }

    public override string ToString() => Point.ToString();

    public bool Equals(Vertex? other)
    {
        return other != null && this.Point == other.Point;
    }
}
