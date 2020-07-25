namespace WeatherService.Services.Models
{
    public class Clouds
    {
        public string Percentage { get; set; }

        public override string ToString()
        {
            return $@"Cloud % rate of sky: {Percentage}%";
        }
    }
}