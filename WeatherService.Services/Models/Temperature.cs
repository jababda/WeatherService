namespace WeatherService.Services.Models
{
    public class Temperature
    {
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public decimal FeelsLike { get; set; }

        public override string ToString()
        {
            return
$@"Min (c): {Min}
Max (c): {Max}
Feels Like (c): {FeelsLike}";
        }
    }
}