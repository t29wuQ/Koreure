using System;
using Newtonsoft.Json;

namespace Koreure.Data
{
    [JsonObject]
    public class Product : DataBase
    {
        public int ID { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        public string[] Tags { get; set; }
    }
}
