using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using ServiceModels = WeatherService.Services.Models;
using OpenWeatherModels = OpenWeather.Models;
using System.Linq;

namespace WeatherService.Services.Wrappers.OpenWeather
{
    public class OpenWeatherMappingProfile : Profile
    {
        public OpenWeatherMappingProfile()
        {
            CreateMap<OpenWeatherModels.Root, ServiceModels.WeatherForecast>()
            .ForMember(d => d.General, opt => opt.MapFrom(s => s.Weather.Single().Main))
            .ForMember(d => d.Details, opt => opt.MapFrom(s => s.Weather.Single().Description))
            .ForMember(d => d.Pressure, opt => opt.MapFrom(s => s.Main.Pressure))
            .ForMember(d => d.Humidity, opt => opt.MapFrom(s => s.Main.Humidity))
            .ForMember(d => d.Sun, opt => opt.MapFrom(s => s.Sys))
            .ForMember(d => d.Temperature, opt => opt.MapFrom(s => s.Main));

            CreateMap<OpenWeatherModels.Clouds, ServiceModels.Clouds>()
                .ForMember(d => d.Percentage, opt => opt.MapFrom(s => s.All));

            CreateMap<OpenWeatherModels.Main, ServiceModels.Temperature>()
                .ForMember(d => d.Min, opt => opt.MapFrom(s => s.TempMin))
                .ForMember(d => d.Max, opt => opt.MapFrom(s => s.TempMax));

            CreateMap<OpenWeatherModels.Wind, ServiceModels.Wind>()
                .ForMember(d => d.Degrees, opt => opt.MapFrom(s => s.Deg));

            CreateMap<OpenWeatherModels.Sys, ServiceModels.SunData>()
                .ForMember(d => d.Sunrise, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.Sunrise).UtcDateTime))
                .ForMember(d => d.Sunset, opt => opt.MapFrom(s => DateTimeOffset.FromUnixTimeSeconds(s.Sunset).UtcDateTime));
        }
    }
}
