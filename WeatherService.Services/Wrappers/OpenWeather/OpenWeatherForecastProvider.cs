using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using OpenWeather.Clients;
using OpenWeather.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Services.Models;

namespace WeatherService.Services.Wrappers.OpenWeather
{
    public class OpenWeatherForecastProvider : IWeatherForecastProvider
    {
        private readonly IOpenWeatherClient _client;
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        private readonly TimeSpan _cacheExpiration = new TimeSpan(0, 5, 0);

        public OpenWeatherForecastProvider(IOpenWeatherClient client, IMemoryCache memoryCache, IMapper mapper)
        {
            _client = client;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }

        public async Task<WeatherForecast> GetForecastForCity(string city)
        {
            var openWeathRes = await _memoryCache.GetOrCreateAsync(city, async e =>
            {
                e.AbsoluteExpirationRelativeToNow = _cacheExpiration;
                return await _client.GetForecast(city);
            });
            return _mapper.Map<WeatherForecast>(openWeathRes);
        }
    }
}
