using Newtonsoft.Json;
using OpenWeather.Config;
using OpenWeather.Exceptions;
using OpenWeather.Models;
using OpenWeather.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenWeather.Clients
{
    public class OpenWeatherClient : IOpenWeatherClient
    {
        private readonly HttpClient _client;
        private readonly IDefaultLocationConfig _config;
        private readonly IUrlBuilder _urlBuilder;

        public OpenWeatherClient(HttpClient client, IDefaultLocationConfig config, IUrlBuilder urlBuilder)
        {
            _client = client;
            _config = config;
            _urlBuilder = urlBuilder;
        }

        public async Task<Root> GetForecast(string city, string state = null, string isoCountryCode = null)
        {
            if (string.IsNullOrWhiteSpace(city)) throw new ArgumentNullException(nameof(city), "City name must be provided");

            state ??= _config.State;
            isoCountryCode ??= _config.IsoCountryCode;

            var url = _urlBuilder.BuildWeatherUrl(city, state, isoCountryCode);
            var res = await _client.GetAsync(url);

            if (!res.IsSuccessStatusCode) throw new OpenWeatherClientException(res);

            var jsonContent = await res.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Root>(jsonContent);
        }
        
    }
}