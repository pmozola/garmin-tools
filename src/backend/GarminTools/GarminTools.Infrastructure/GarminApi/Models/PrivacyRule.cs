using System.Text.Json.Serialization;

namespace GarminTools.Infrastructure.GarminApi.Models;

public class PrivacyRule
{
    [JsonPropertyName("typeId")] public int TypeId { get; set; }

    [JsonPropertyName("typeKey")] public string TypeKey { get; set; }
}