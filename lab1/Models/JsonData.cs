using System.Collections.Generic;
using Newtonsoft.Json;

namespace lab1.Models
{
    [JsonObject]
    public class JsonData
    {
        [JsonProperty(PropertyName = "users")]
        public List<User> Users { get; set; }

        [JsonProperty(PropertyName = "funcInfo")]
        public CapchaFunc FunctionInfo { get; set; }
    }
}