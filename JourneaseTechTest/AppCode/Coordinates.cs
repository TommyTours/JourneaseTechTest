using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JourneaseTechTest.AppCode
{
    [JsonObject]
    public class Coordinates
    {
        [JsonProperty]
        public decimal latitude { get; set; }
        [JsonProperty]
        public decimal longitude { get; set; }
    }
}
