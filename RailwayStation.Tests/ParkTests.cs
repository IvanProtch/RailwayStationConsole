using RailwayStation.Interfaces;
using RailwayStation.Model;
using System.Drawing;

namespace RailwayStation.Tests;

[TestClass]
public class ParkTests
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
    public void Area_Property_ShouldReturnValidPoints()
    {

        var expectedPoints = new PointF[]
        {
            new PointF(0, 0),
            new PointF(0, 3),
            new PointF(5, 15),
            new PointF(2, 10)
        };

        var park = _station.Parks[0];

        Assert.IsNotNull(park.Area);
        Assert.AreEqual(2, park.Paths.Count);
        Assert.AreEqual(4, park.Area.Length);

        foreach (var expectedPoint in expectedPoints)
        {
            Assert.IsTrue(park.Area.Contains(expectedPoint), $"Ожидаемая точка области {expectedPoint} не найдена.");
        }
    }
}
