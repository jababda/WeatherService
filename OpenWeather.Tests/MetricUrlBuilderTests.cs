using OpenWeather.Config;
using OpenWeather.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Sdk;

namespace OpenWeather.Tests
{
    public class MetricUrlBuilderTests
    {
        private MetricUrlBuilder _sut;
        private class MockConfig : IApiConfig
        {
            public string BaseAddress { get; set; }

            public string ApiKey { get; set; }
        }

        private MockConfig _config;
        public MetricUrlBuilderTests()
        {
            _config = new MockConfig
            {
                ApiKey = "123",
                BaseAddress = "abc"
            };
            _sut = new MetricUrlBuilder(_config);
        }

        [Theory]
        [InlineData("perth", "wa", "aus")]
        [InlineData("", "", "")]
        [InlineData(null, null, null)]
        public void BuildWeatherUrlReturnsExpectedResult(string city, string state, string country)
        {
            var expected = $"{_config.BaseAddress}?q={city},{state},{country}&appid={_config.ApiKey}&units=metric";
            var res = _sut.BuildWeatherUrl(city, state, country);
            Assert.Equal(expected, res);
        }

    }

    
}
