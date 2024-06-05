using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Models
{
    public class Car
    {
        [JsonProperty("plate")]
        public string Plate { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("year_model")]
        public int YearModel { get; set; }
        
        [JsonProperty("year_production")]
        public int YearProduction { get; set; }
        
        [JsonProperty("color")]
        public string Color { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Plate} - {YearProduction} - {Color}";
        }
    }
}
