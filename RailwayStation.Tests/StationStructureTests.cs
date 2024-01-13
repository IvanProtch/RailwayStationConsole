using RailwayStation.Interfaces;

namespace RailwayStation.Tests;

[TestClass]
public class StationStructureTests
{
    private IStationScheme _station;

    [TestInitialize]
    public void Initialize()
    {
        //Для простоты берем IStationScheme из хелпера
        //в реальном проекте использовался бы Mock
        _station = StationHelper.CreateStation();
    }

    [TestMethod]
    public void ParkPathsContainsInStationPaths()
    {
        var parkPaths = _station.Parks.SelectMany(park => park.Paths);
        var intersection = _station.Paths.Intersect(parkPaths);

        Assert.IsNotNull(intersection);
        Assert.IsTrue(intersection.SequenceEqual(parkPaths));
    }

    [TestMethod]
    public void PathSegmentsContainsInStationSegments()
    {
        var pathSegments = _station.Paths.SelectMany(park => park.Segments);
        var intersection = _station.Segments.Intersect(pathSegments);

        Assert.IsNotNull(intersection);
        Assert.IsTrue(intersection.SequenceEqual(pathSegments));
    }
}
