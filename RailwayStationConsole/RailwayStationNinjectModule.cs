using Ninject.Extensions.Factory;
using Ninject.Modules;
using RailwayStation;
using RailwayStation.Interfaces;
using RailwayStation.Model;

namespace RailwayStationConsole;

internal class RailwayStationNinjectModule : NinjectModule
{
    public override void Load()
    {
        //Регистрация служб
        Bind<IStationParserService>().To<StationParserService>();

        //Регистрация фабрик
        Bind<IStationSchemeFactory>().ToFactory();

        //Регистрация всех интерфейсов модели
        Bind<IStationScheme>().To<Station>();
        Bind<IPark>().To<Park>();
        Bind<IPath>().To<RailwayStation.Model.Path>();
        Bind<IPathSegment>().To<PathSegment>();
        Bind<IVertex>().To<Vertex>();
    }
}
