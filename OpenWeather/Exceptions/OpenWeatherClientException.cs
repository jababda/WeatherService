using System;
using System.Net.Http;
using System.Runtime.Serialization;

namespace OpenWeather.Exceptions
{
    [Serializable]
    public class OpenWeatherClientException : Exception
    {
        public HttpResponseMessage Res { get; }

        public OpenWeatherClientException()
        {
        }

        public OpenWeatherClientException(HttpResponseMessage res)
        {
            Res = res;
        }

        public OpenWeatherClientException(string message) : base(message)
        {
        }

        public OpenWeatherClientException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected OpenWeatherClientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public override string ToString()
        {
            var content = Res.Content.ReadAsStringAsync().Result;
            return
@$"There was an error communicating with OpenWeather. Code: {Res.StatusCode}
Content: {content}";

        }
    }
}