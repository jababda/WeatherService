using Newtonsoft.Json;
using OpenWeather.Exceptions;
using System;
using WeatherService.Services;

namespace WeatherService.Console
{
    /// <summary>
    /// Top level service for application logic
    /// </summary>
    class WeatherServiceApplication : IWeatherServiceApplication
    {
        private readonly IWeatherForecastProvider _forecastProvider;
        private readonly IInputHandler _inputHandler;
        private readonly IOutputHandler _outputHandler;
        private readonly IConfigDisplayGenerator _configDisplayGenerator;

        public WeatherServiceApplication(IWeatherForecastProvider forecastProvider, IInputHandler inputHandler, IOutputHandler outputHandler, IConfigDisplayGenerator configDisplayGenerator)
        {
            _forecastProvider = forecastProvider;
            _inputHandler = inputHandler;
            _outputHandler = outputHandler;
            _configDisplayGenerator = configDisplayGenerator;
        }

        public void Run()
        {
            _outputHandler.Output(_configDisplayGenerator.BuildConfigDisplayString());
            while (true)
            {
                try
                {
                    _outputHandler.Output(Environment.NewLine + "Please enter city name");
                    var city = _inputHandler.GetCityString();
                    var forecast = _forecastProvider.GetForecastForCity(city).Result;
                    _outputHandler.Output(forecast.ToString());
                }
                catch (Exception e)
                {
                    _outputHandler.Output(e.ToString());
                }
            }
        }
    }
}
