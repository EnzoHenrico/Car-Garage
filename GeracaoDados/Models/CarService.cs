using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class CarService
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("car_plate")]
        public Car Car { get; set; }
        
        [JsonProperty("service_id")]
        public Service Service { get; set; }
        
        [JsonProperty("status")]
        public bool Status { get; set; }

        public static readonly string InsertOne = " INSERT INTO CarService ([car_plate], [service_id], [status]) VALUES(@CarPlate, @ServiceId, @Status); SELECT CAST(SCOPE_IDENTITY() as int) ";
        public static readonly string SelectAll = " SELECT" +
                                                  "    cs.[id]," +
                                                  "    cs.[status]," +
                                                  "    cs.[car_plate]," +
                                                  "    cs.[service_id]," +
                                                  "    c.[plate]," +
                                                  "    c.[name]," +
                                                  "    c.[year_model] YearModel," +
                                                  "    c.[year_production] YearProduction," +
                                                  "    c.[color]," +
                                                  "    s.[id]," +
                                                  "    s.[description]" +
                                                  "FROM " +
                                                  "    [CarService] cs" +
                                                  "INNER JOIN" +
                                                  "    [Car] c ON cs.[car_plate] = c.[plate]" +
                                                  "INNER JOIN" +
                                                  "    [Service] s ON cs.[service_id] = s.[id] ";
    }
}
