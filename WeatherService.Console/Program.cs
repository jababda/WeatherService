using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using Microsoft.Extensions.Caching.Memory;
using OpenWeather.Extensions;
using System;
using System.Data;
using WeatherService.Services.Wrappers.OpenWeather;

namespace WeatherService.Console
{
    /// <summary>
    /// Responsible for the lifetime of the application
    /// </summary>
    partial class Program
    {
        static void Main(string[] args)
        {
            var config = new SimpleConfig
            {
                BaseAddress = "http://api.openweathermap.org/data/2.5/weather",
                ApiKey = "62ffa8c4c1dfbc438b162198e174c4cb",
                State = "wa",
                IsoCountryCode = "au"
            };

            var cacheOptions = new MemoryCacheOptions();

            if (args.Length > 0) config.State = args[0];
            if (args.Length > 1) config.IsoCountryCode = args[1];

            var builder = new ContainerBuilder();
            builder.RegisterType<WeatherServiceApplication>().AsImplementedInterfaces();
            builder.RegisterInstance(config).AsImplementedInterfaces();
            builder.RegisterModule<OpenWeatherModule>();
            builder.RegisterType<OpenWeatherForecastProvider>().AsImplementedInterfaces();

            builder.RegisterType<ConsoleInputHandler>().AsImplementedInterfaces();
            builder.RegisterType<ConsoleOutputHandler>().AsImplementedInterfaces();

            builder.RegisterInstance(cacheOptions).AsImplementedInterfaces();
            builder.RegisterType<MemoryCache>().AsImplementedInterfaces();
            builder.AddAutoMapper(typeof(OpenWeatherMappingProfile).Assembly);

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var applicaiton = scope.Resolve<IWeatherServiceApplication>();
                applicaiton.Run();
            }
        }
    }
}
