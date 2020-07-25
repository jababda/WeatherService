using System;
using Xunit;
using AutoMapper;
using WeatherService.Services.Wrappers.OpenWeather;

namespace WeatherService.Services.Tests
{
    public class AutoMapperTests
    {
        [Fact]
        public void OpenWeatherMappingProfileIsValid()
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<OpenWeatherMappingProfile>());

            configuration.AssertConfigurationIsValid();
        }
    }
}
