using RailwayStation.Interfaces;

namespace RailwayStation;

public class StationParserService : IStationParserService
{
    private readonly IStationSchemeFactory _stationFactory;

    public StationParserService(IStationSchemeFactory stationFactory)
    {
        _stationFactory = stationFactory ?? throw new ArgumentNullException(nameof(stationFactory));
    }

    /// <summary>
    /// Получить схему станции из исходных данных
    /// </summary>
    /// <param name="rawData">Исходные данные (возможен любой формат, но для примера возьмем string)</param>
    /// <returns>IStationScheme</returns>
    /// <exception cref="ArgumentNullException"></exception>
    public IStationScheme GetStation(string rawData)
    {
        if (rawData == null) throw new ArgumentNullException(nameof(rawData));

        List<IPathSegment> pathSegments = ParseSegments(rawData);
        List<IPath> paths = ParsePaths(rawData);
        List<IPark> parks = ParseParks(rawData);

        return _stationFactory.CreateStation(pathSegments, paths, parks);
    }

    private List<IPathSegment> ParseSegments(string rawData)
    {
        // TODO: Реализовать логику разбора сегментов
        return Enumerable.Empty<IPathSegment>().ToList();
    }

    private List<IPath> ParsePaths(string rawData)
    {
        // TODO: Реализовать логику разбора путей
        return Enumerable.Empty<IPath>().ToList();
    }

    private List<IPark> ParseParks(string rawData)
    {
        // TODO: Реализовать логику разбора парков
        return Enumerable.Empty<IPark>().ToList();
    }
}
