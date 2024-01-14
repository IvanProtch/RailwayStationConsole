namespace RailwayStation.Interfaces;

public interface IStationParserService
{
    /// <summary>
    /// Получить схему станции из исходных данных
    /// </summary>
    /// <param name="rawData">Исходные данные (возможен любой формат, но для примера возьмем string)</param>
    /// <returns>IStationScheme</returns>
    IStationScheme GetStation(string rawData);
}
