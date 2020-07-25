using OpenWeather.Models;
using System.Threading.Tasks;

namespace OpenWeather.Clients
{
    public interface IOpenWeatherClient
    {
        Task<Root> GetForecast(string city, string state = null, string isoCountryCode = null);
    }
}