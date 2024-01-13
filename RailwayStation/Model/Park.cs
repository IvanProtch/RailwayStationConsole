using RailwayStation.Interfaces;
using System.Drawing;

namespace RailwayStation.Model
{
    public class Park : IPark
    {
        public string Name { get; private set; }
        public List<IPath> Paths { get; private set; } = new List<IPath>();
        private Lazy<PointF[]> _area;

        public Park(string name, List<IPath> paths)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            Paths = paths ?? throw new ArgumentNullException(nameof(paths));

            _area = new Lazy<PointF[]>(() => GetArea().ToArray());
        }

        public PointF[] Area => _area.Value;

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
            if (Paths.Count == 1)
                return $"{Name}: [{Paths.First()}]";

            return $"{Name}: [{string.Join(", ", Paths)}]";
        }
    }
}
