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

        public static readonly string InsertOne = " INSERT INTO Car ([plate], [name], [year_model], [year_production], [color]) Values (@Plate, @Name, @YearModel, @YearProduction, @Color) ";
        public static readonly string SelectAll = " SELECT [plate], [name], [year_model], [year_production], [color] FROM [Car] ";

        public override string ToString()
        {
            return $"{Name} - {Plate} - {YearProduction} - {Color}";
        }
    }
}
