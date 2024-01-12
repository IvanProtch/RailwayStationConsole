using RailwayStation.Interfaces;
using RailwayStation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayStation
{
    public class StationParserService : IStationParserService
    {
        private readonly IStationSchemeFactory stationFactory;

        public StationParserService(IStationSchemeFactory stationFactory)
        {
            this.stationFactory = stationFactory;
        }

        //из rawData вытягиваются нужные значения, через factory создаются все необходимые для Station сущности
        public IStationScheme GetStation(string rawData)
        {
            List<IPathSegment> pathSegments = ParseSegments(rawData);
            List<IPath> paths = ParsePaths(rawData);
            List<IPark> parks = ParseParks(rawData);

            return stationFactory.CreateStation(pathSegments, paths, parks);
        }

        private List<IPathSegment> ParseSegments(string rawData)
        {
            return new List<IPathSegment>();
        }

        private List<IPath> ParsePaths(string rawData)
        {
            return new List<IPath>();
        }

        private List<IPark> ParseParks(string rawData)
        {
            return new List<IPark>();
        }
    }
}
