using Newtonsoft.Json;

namespace Domain
{
    [JsonObject]
    public class User
    {
        [JsonProperty(PropertyName = "username")]
        public string UserName { get; set; }

        [JsonProperty(PropertyName = "pwd")]
        public string Password { get; set; } 
    }
}