using System;

namespace WeatherService.Services.Models
{
    public class SunData
    {
        public DateTime Sunrise { get; set; }
        public DateTime Sunset { get; set; }

        public override string ToString()
        {
            return
@$"Sunrise: {Sunrise.ToLocalTime()}
Sunset: { Sunset.ToLocalTime()}";
        }
    }
}