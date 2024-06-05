using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    [JsonObject]
    internal class CarService
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("car_plate")]
        public string CarPalte { get; set; }
        
        [JsonProperty("service_id")]
        public int sreviceId { get; set; }
        
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
}
