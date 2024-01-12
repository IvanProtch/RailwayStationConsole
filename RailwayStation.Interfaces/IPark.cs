using System.Drawing;

namespace RailwayStation.Interfaces;

public interface IPark
{
    string Name { get; }
    List<IPath> Paths { get; }
    PointF[] Area { get; }
}
