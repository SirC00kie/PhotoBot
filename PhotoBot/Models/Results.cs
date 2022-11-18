using Newtonsoft.Json;

namespace PhotoBot.Models;

public class Results
{
    [JsonProperty("description", Required = Required.Always)]
    public string Description { get; set; } = null!;
    
    [JsonProperty("urls", Required = Required.Always)]
    public Urls Urls { get; set; } = null!;
}