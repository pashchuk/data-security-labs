using Newtonsoft.Json;

namespace Domain
{
    [JsonObject]
    public class CapchaFunc
    {
        [JsonProperty(PropertyName = "functionA")]
        public int FunctionA { get; set; } 

        [JsonProperty(PropertyName = "functionB")]
        public int FunctionB { get; set; }

        [JsonProperty(PropertyName = "currentX")]
        public int CurrentX { get; set; }
    }
}