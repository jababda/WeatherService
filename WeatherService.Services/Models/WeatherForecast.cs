
using System;

namespace WeatherService.Services.Models
{
    public class WeatherForecast
    {
        public string General { get; set; }
        public string Details { get; set; }
        public decimal Visibility { get; set; }
        public decimal Pressure { get; set; }
        public decimal Humidity { get; set; }
        public SunData Sun {get;set;}
        public Temperature Temperature { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }

        public override string ToString()
        {
            return
@$"General: {General}
Details: {Details}
Visibility (m): {Visibility}
Pressure: {Pressure}
Humidity: {Humidity}
{Sun}
{Temperature.ToString()}
{Wind.ToString()}
{Clouds.ToString()}";
        }
    }
}