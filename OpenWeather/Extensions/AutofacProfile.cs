using Autofac;
using OpenWeather.Clients;
using OpenWeather.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace OpenWeather.Extensions
{
    public class OpenWeatherModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(ctx => new HttpClient());
            builder.RegisterType<MetricUrlBuilder>().AsImplementedInterfaces();
            builder.RegisterType<OpenWeatherClient>().AsImplementedInterfaces();
        }
    }
}
