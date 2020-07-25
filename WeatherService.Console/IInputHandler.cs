namespace WeatherService.Console
{
    internal interface IInputHandler
    {
        string GetCityString();
    }

    internal class ConsoleInputHandler : IInputHandler
    {
        public string GetCityString()
        {
            return System.Console.ReadLine();
        }
    }
}