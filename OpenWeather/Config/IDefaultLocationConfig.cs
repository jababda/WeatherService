namespace OpenWeather.Config
{
    public interface IDefaultLocationConfig
    {
        string State { get; }
        string IsoCountryCode { get; }
    }
}