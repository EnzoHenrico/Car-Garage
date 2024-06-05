using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    public class CarService
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("car_plate")]
        public string CarPalte { get; set; }
        
        [JsonProperty("service_id")]
        public int sreviceId { get; set; }
        
        [JsonProperty("status")]
        public bool Status { get; set; }

        public static readonly string InsertOne = " INSERT [car_plate] [service_id] [status] INTO Service VALUES(@CarPlate, @ServiceId, @Status) ";
    }
}
