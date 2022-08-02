using System.Text.Json.Serialization;

namespace GoveeApiClientNet.GetDeviceState;

public record DeviceState
{
    [JsonPropertyName("device")]
    public string DeviceId { get; set; }

    public string Model { get; set; }
    
    public string Name { get; set; }
    
    [JsonIgnore]
    public Properties Properties { get; set; }
};