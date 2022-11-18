using Newtonsoft.Json;

namespace PhotoBot.Models;

public class Urls
{
    [JsonProperty("regular", Required = Required.Always)]
    public string Regular { get; set; } = null!;
    
    [JsonProperty("raw", Required = Required.Always)]
    public string Raw { get; set; } = null!;
}