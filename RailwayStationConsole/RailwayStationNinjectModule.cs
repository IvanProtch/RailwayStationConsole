using Ninject.Extensions.Factory;
using Ninject.Modules;
using RailwayStation;
using RailwayStation.Interfaces;
using RailwayStation.Model;

namespace RailwayStationConsole
{
    internal class RailwayStationNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IStationParserService>().To<StationParserService>();
            Bind<IStationSchemeFactory>().ToFactory();
            Bind<IStationScheme>().To<Station>();
            Bind<IPark>().To<Park>();
            Bind<IPath>().To<RailwayStation.Model.Path>();
            Bind<IPathSegment>().To<PathSegment>();
            Bind<IVertex>().To<Vertex>();
        }
    }
}
