using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Models
{
    public class Service
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }

        public static readonly string InsertOne = " INSERT INTO Service ([description]) VALUES(@Description); SELECT CAST(SCOPE_IDENTITY() as int) ";
        public static readonly string SelectAll = " SELECT [id], [description] FROM Service ";

        public override string ToString()
        {
            return $"{Id}: {Description}";
        }
    }
}
