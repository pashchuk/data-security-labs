using Newtonsoft.Json;

namespace lab1.Models
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