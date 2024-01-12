using RailwayStation.Interfaces;
using System.Drawing;

namespace RailwayStation.Model;

public class Park : IPark
{
    public string Name { get; private set; }

    public List<IPath> Paths { get; private set; } = new List<IPath>();

    public Park(string name, List<IPath> paths)
    {
        Name = name;
        Paths = paths;
    }

    private PointF[] _area;

    /// <summary>
    /// Фигура, ограничивающая область парка
    /// </summary>
    public PointF[] Area 
    { 
        get
        {
            if(_area == null)
                _area = GetArea().ToArray();

            return _area;
        }
    }

    private IEnumerable<PointF> GetArea()
    {
        foreach (var path in Paths)
        {
            yield return path.StartSegment.Start.Point;
        }

        foreach (var path in Paths)
        {
            yield return path.EndSegment.End.Point;
        }
    }

    public override string ToString()
    {
        if(Paths.Count == 1) return $"{Name}: [{Paths.First()}]";

        string pathsString = string.Join(", ", Paths.Select(path => path));
        return $"{Name}: [{pathsString}]";
    }
}
