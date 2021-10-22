using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReceiptScanner
{
    public class Recipe
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("domestic")]
        public bool Domestic { get; set; }
        [JsonPropertyName("price")]
        public decimal Price { get; set; }
        [JsonPropertyName("weight")]
        public int Weight { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
