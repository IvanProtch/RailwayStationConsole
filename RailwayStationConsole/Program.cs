using System;
using Ninject;
using RailwayStation;
using RailwayStation.Interfaces;
using RailwayStationConsole;

class Program
{
    static void Main()
    {
        IKernel kernel = new StandardKernel(new RailwayStationNinjectModule());

        //Как можно было бы получить IStationScheme, если бы были исходные данные для парсера:
        IStationParserService parserService = kernel.Get<IStationParserService>();
        IStationScheme stationScheme = parserService.GetStation(string.Empty);

        //Получение захардкоженного IStationScheme
        stationScheme = StationHelper.CreateStation();

        PrintParks(stationScheme);
        PrintSegments(stationScheme);
        FindAndPrintShortestPath(stationScheme);

        Console.ReadLine();
    }

    static void PrintParks(IStationScheme stationScheme)
    {
        Console.WriteLine("Все парки станции:");
        foreach (var park in stationScheme.Parks)
        {
            Console.WriteLine(park);
        }
    }

    static void PrintSegments(IStationScheme stationScheme)
    {
        Console.WriteLine("Все участки станции:");
        foreach (var path in stationScheme.Paths)
        {
            foreach (var segment in path.Segments)
            {
                Console.WriteLine(segment);
            }
        }
    }

    static void FindAndPrintShortestPath(IStationScheme stationScheme)
    {
        var startSegment = stationScheme.Paths[0].StartSegment;
        var endSegment = stationScheme.Paths[0].EndSegment;

        try
        {
            var shortestPathBetweenFirstPathSegments = stationScheme.FindShortestPath(startSegment, endSegment);

            Console.WriteLine($"Кратчайший путь между сегментами {startSegment} и {endSegment}");
            foreach (var segment in shortestPathBetweenFirstPathSegments)
            {
                Console.WriteLine(segment);
            }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"Ошибка при поиске кратчайшего пути: {ex.Message}");
        }
    }
}