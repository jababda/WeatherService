using System;
using Xunit;
using OpenWeather;
using OpenWeather.Clients;
using OpenWeather.Config;
using System.Net.Http;
using System.Threading.Tasks;
using OpenWeather.Services;
using OpenWeather.Exceptions;
using NSubstitute;

namespace OpenWeather.IntegrationTests
{
    public class OpenWeatherClientTests
    {
        private OpenWeatherClient _sut;

        private class MockConfig : IApiConfig, IDefaultLocationConfig
        {
            public string BaseAddress { get; set; }
            public string ApiKey { get; set; }
            public string State { get; set; }
            public string IsoCountryCode { get; set; }
        }

        private MockConfig _config;

        public OpenWeatherClientTests()
        {
            _config = new MockConfig
            {
                BaseAddress = "http://api.openweathermap.org/data/2.5/weather",
                ApiKey = "62ffa8c4c1dfbc438b162198e174c4cb",
                State = "wa",
                IsoCountryCode = "au"
            };

            _sut = new OpenWeatherClient(new HttpClient(), _config, new MetricUrlBuilder(_config));
        }

        [Fact]
        public async Task GetForecastReturnsDataWithJustCityName()
        {
            var res = await _sut.GetForecast("perth");
            Assert.NotNull(res);
        }

        [Fact]
        public async Task GetForecastThrowsWhenNameIsNotProvided()
        {
            await Assert.ThrowsAnyAsync<ArgumentNullException>(() => _sut.GetForecast(""));
        }

        [Fact]
        public async Task GetForecastThrowsWhenApiIsNotProivded()
        {
            _config.ApiKey = "";
            await Assert.ThrowsAnyAsync<OpenWeatherClientException>(() => _sut.GetForecast("perth"));
        }
    }
}
