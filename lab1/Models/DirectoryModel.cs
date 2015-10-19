using System.Collections.Generic;
using Domain;
using Newtonsoft.Json;

namespace lab1.Models
{
    [JsonObject]
    public class DirectoryModel
    {
        public string DirectoryName { get; set; }
        public User Owner { get; set; }
    }
}