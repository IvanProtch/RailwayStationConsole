using RailwayStation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation.Model;

public class Path : IPath
{
    public string Name { get; }

    public List<IPathSegment> Segments { get; private set; }

    public IPathSegment StartSegment { get; private set;}

    public IPathSegment EndSegment { get; private set; }

    public Path(string name, List<IPathSegment> segments, IPathSegment start, IPathSegment end)
    {
        Name = name;
        Segments = segments;
        StartSegment = start;
        EndSegment = end;
    }

    public override string ToString() => Name;
}
