using Ninject;
using RailwayStation;
using RailwayStation.Interfaces;
using RailwayStationConsole;

IKernel kernel = new StandardKernel(new RailwayStationNinjectModule());

//как можно было бы получить IStationScheme, если бы были исходные данные для парсера:
IStationParserService parserService = kernel.Get<IStationParserService>();
IStationScheme stationScheme = parserService.GetStation(string.Empty);

//как будет получен захардкоденый IStationScheme
stationScheme = StationHelper.CreateStation();

Console.WriteLine("Все парки станции:");
foreach (var park in stationScheme.Parks)
{
    Console.WriteLine(park);
}

Console.WriteLine("Все участки станции:");
foreach (var path in stationScheme.Paths)
{
	foreach (var segment in path.Segments)
	{
		Console.WriteLine(segment);
    }
}

var startSegment = stationScheme.Paths[0].StartSegment;
var endSegment = stationScheme.Paths[0].EndSegment;

var shortestPathBetweenFirstPathSegments = stationScheme.FindShortestPath(startSegment, endSegment);

Console.WriteLine($"Кратчайший путь между сегментами {startSegment} и {endSegment}");
foreach (var segment in shortestPathBetweenFirstPathSegments)
{
    Console.WriteLine(segment);
}