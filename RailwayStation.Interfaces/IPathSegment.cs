using System.Drawing;

namespace RailwayStation.Interfaces
{
    public interface IPathSegment
    {
        IVertex Start { get; }
        IVertex End { get; }

        int Number { get; }
        string Name { get; }
    }
}
