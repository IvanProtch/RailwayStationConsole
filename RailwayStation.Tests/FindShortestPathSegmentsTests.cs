using RailwayStation.Interfaces;

namespace RailwayStation.Tests;

[TestClass]
public class FindShortestPathSegmentsTests
{
    private IStationScheme _station;

    [TestInitialize]
    public void Initialize()
    {
        _station = StationHelper.CreateStation();
    }

    [TestMethod]
    public void FindShortestPathSegments_ValidInput_ShouldReturnShortestPath()
    {
        var startSegment = _station.Paths[0].StartSegment;
        var endSegment = _station.Paths[0].EndSegment;

        var shortestPath = _station.FindShortestPath(startSegment, endSegment);

        Assert.IsNotNull(shortestPath);
        Assert.IsTrue(shortestPath.Count > 0);
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void FindShortestPathSegments_InvalidInput_ShouldThrowException()
    {
        var startSegment = _station.Segments[0];
        var endSegment = _station.Segments[3];

        _station.FindShortestPath(startSegment, endSegment);
    }
    
    //TODO: добавить кейс для выбора кратчайшего пути из нескольких возможных
}