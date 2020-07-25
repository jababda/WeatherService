// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
using Newtonsoft.Json;

namespace OpenWeather.Models
{
    public class Clouds
    {

        [JsonProperty("all")]
        public int All { get; set; }

    }
}