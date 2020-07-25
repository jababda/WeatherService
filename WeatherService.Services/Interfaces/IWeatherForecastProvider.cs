using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WeatherService.Services.Models;

namespace WeatherService.Services
{
    public interface IWeatherForecastProvider
    {
        Task<WeatherForecast> GetForecastForCity(string city);
    }
}
