namespace WeatherService.Services.Models
{
    public class Wind
    {
        public decimal Speed { get; set; }
        public decimal Degrees { get; set; }

        public override string ToString()
        {
            return
$@"Wind Speed (m/s): {Speed}
Wind Degrees: {Degrees}";
        }
    }
}