using RailwayStation.Interfaces;

namespace RailwayStation.Tests;

[TestClass]
public class StationStructureTests
{
    private IStationScheme station;

    [TestInitialize]
    public void Initialize()
    {
        station = StationHelper.CreateStation();
    }

    [TestMethod]
    public void ParkPathsContainsInStationPaths()
    {
        var parkPaths = station.Parks.SelectMany(park => park.Paths);
        var intersection = station.Paths.Intersect(parkPaths);

        Assert.IsNotNull(intersection);
        Assert.IsTrue(intersection.SequenceEqual(parkPaths));
    }

    [TestMethod]
    public void PathSegmentsContainsInStationSegments()
    {
        var pathSegments = station.Paths.SelectMany(park => park.Segments);
        var intersection = station.Segments.Intersect(pathSegments);

        Assert.IsNotNull(intersection);
        Assert.IsTrue(intersection.SequenceEqual(pathSegments));
    }
}
