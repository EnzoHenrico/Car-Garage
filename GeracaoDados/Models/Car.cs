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

        public static readonly string InsertOne = " INSERT [plate] [name] [year_model] [year_production] [color] INTO Car Values (@Plate, @Name, @YearModel, @YearProduction, @Color) ";

        public override string ToString()
        {
            return $"{Name} - {Plate} - {YearProduction} - {Color}";
        }
    }
}
