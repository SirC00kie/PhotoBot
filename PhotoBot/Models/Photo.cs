using Newtonsoft.Json;

namespace PhotoBot.Models;

public class Photo
{
    [JsonProperty("results", Required = Required.Always)]
    public Results Results { get; set; } = null!;
}