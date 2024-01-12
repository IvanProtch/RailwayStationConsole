namespace RailwayStation.Interfaces;

public interface IStationParserService
{
    IStationScheme GetStation(string rawData);
}
