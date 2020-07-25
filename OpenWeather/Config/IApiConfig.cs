namespace OpenWeather.Config
{
    public interface IApiConfig
    {
        string BaseAddress { get; }
        string ApiKey { get; }
    }
}