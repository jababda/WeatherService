using OpenWeather.Config;

namespace WeatherService.Console
{
    partial class Program
    {
        public class SimpleConfig : IApiConfig, IDefaultLocationConfig, IConfigDisplayGenerator
        {
            public string BaseAddress { get; set; }
            public string ApiKey { get; set; }
            public string State { get; set; }
            public string IsoCountryCode { get; set; }
            public string BuildConfigDisplayString() => $"Using state {State}, and ISO country code {IsoCountryCode}";
        }
    }
}
