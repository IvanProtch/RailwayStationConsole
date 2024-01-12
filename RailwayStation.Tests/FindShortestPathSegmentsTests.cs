using RailwayStation.Interfaces;
using RailwayStation.Model;

namespace RailwayStation.Tests;

[TestClass]
public class FindShortestPathSegmentsTests
{
    private IStationScheme station;

    [TestInitialize]
    public void Initialize()
    {
        station = StationHelper.CreateStation();
    }

    [TestMethod]
    public void FindShortestPathSegments_ValidInput_ShouldReturnShortestPath()
    {
        var startSegment = station.Paths[0].StartSegment;
        var endSegment = station.Paths[0].EndSegment;

        var shortestPath = station.FindShortestPath(startSegment, endSegment);

        Assert.IsNotNull(shortestPath);
        Assert.IsTrue(shortestPath.Count > 0);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void FindShortestPathSegments_InvalidInput_ShouldThrowException()
    {
        var startSegment = station.Segments[0];
        var endSegment = station.Segments[3];

        station.FindShortestPath(startSegment, endSegment);
    }
    
    //TODO: добавить кейс для выбора кратчайшего пути из нескольких возможных
}