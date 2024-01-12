using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation.Interfaces
{
    public interface IStationScheme
    {
        List<IPathSegment> Segments { get; }
        List<IPath> Paths { get; }
        List<IPark> Parks { get; }

        List<IPathSegment> FindShortestPath(IPathSegment startSegment, IPathSegment endSegment);
    }
}
