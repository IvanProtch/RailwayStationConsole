using RailwayStation.Interfaces;

namespace RailwayStation.Tests;

[TestClass]
public class ParkTests
{
    private IStationScheme station;

    [TestInitialize]
    public void Initialize()
    {
        station = StationHelper.CreateStation();
    }

    [TestMethod]
    public void Area_Property_ShouldReturnValidPoints()
    {
        var park1 = station.Parks[0];

        Assert.IsNotNull(park1.Area);
        Assert.AreEqual(2, park1.Paths.Count);
        Assert.AreEqual(4, park1.Area.Length);
    }
}
