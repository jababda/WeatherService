namespace WeatherService.Console
{
    internal interface IOutputHandler
    {
        void Output(string output);
    }

    internal class ConsoleOutputHandler : IOutputHandler
    {
        public void Output(string output)
        {
            System.Console.WriteLine(output);
        }
    }
}