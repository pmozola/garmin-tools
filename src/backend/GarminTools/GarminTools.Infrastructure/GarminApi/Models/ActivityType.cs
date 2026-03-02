// Root myDeserializedClass = JsonSerializer.Deserialize<List<Root>>(myJsonResponse);

using System.Text.Json.Serialization;

namespace GarminTools.Infrastructure.GarminApi.Models;

public class ActivityType
{
    [JsonPropertyName("typeId")] public int TypeId { get; set; }

    [JsonPropertyName("typeKey")] public string TypeKey { get; set; }

    [JsonPropertyName("parentTypeId")] public int ParentTypeId { get; set; }

    [JsonPropertyName("isHidden")] public bool IsHidden { get; set; }

    [JsonPropertyName("restricted")] public bool Restricted { get; set; }

    [JsonPropertyName("trimmable")] public bool Trimmable { get; set; }
}