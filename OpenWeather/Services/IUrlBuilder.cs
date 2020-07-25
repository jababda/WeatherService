namespace OpenWeather.Services
{
    public interface IUrlBuilder
    {
        string BuildWeatherUrl(string city, string stateCode, string isoCountryCode);
    }
}