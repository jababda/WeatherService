using OpenWeather.Config;

namespace OpenWeather.Services
{
    public class MetricUrlBuilder : IUrlBuilder
    {
        private readonly IApiConfig _config;

        public MetricUrlBuilder(IApiConfig config)
        {
            _config = config;
        }

        public string BuildWeatherUrl(string city, string stateCode, string isoCountryCode)
        {
            return $"{_config.BaseAddress}?q={city},{stateCode},{isoCountryCode}&appid={_config.ApiKey}&units=metric";
        }
    }
}