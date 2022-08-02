using System.Text.Json;

namespace GoveeApiClientNet.GetDeviceState;

public static class DeserializeHelper
{
    public static Properties DeserializeProperties(string payload)
    {
        var jsonProperties = JsonDocument.Parse(payload).RootElement.GetProperty("data").GetProperty("properties")
            .EnumerateArray();

        var properties = new Properties();

        var onlineProperty = jsonProperties.Where(x => x.TryGetProperty("online", out _)).ToList();

        if (onlineProperty.Any())
        {
            try
            {
                properties.Online = bool.Parse(onlineProperty.First().GetProperty("online").GetString());
            }
            catch
            {
                properties.Online = onlineProperty.First().GetProperty("online").GetBoolean();
            }
        }

        var powerStateProperty = jsonProperties.Where(x => x.TryGetProperty("powerState", out _)).ToList();

        if (powerStateProperty.Any())
        {
            var powerStateString = powerStateProperty.First().GetProperty("powerState").GetString();
            properties.PowerState = powerStateString == "off" ? PowerState.Off : PowerState.On;
        }

        var brightnessProperty = jsonProperties.Where(x => x.TryGetProperty("brightness", out _)).ToList();

        if (brightnessProperty.Any())
        {
            properties.Brightness = brightnessProperty.First().GetProperty("brightness").GetInt16();
        }

        var colorProperty = jsonProperties.Where(x => x.TryGetProperty("color", out _)).ToList();

        if (colorProperty.Any())
        {
            var colorR = colorProperty.First().GetProperty("color").GetProperty("r").GetInt16();
            var colorG = colorProperty.First().GetProperty("color").GetProperty("g").GetInt16();
            var colorB = colorProperty.First().GetProperty("color").GetProperty("b").GetInt16();
            properties.Color = new RgbColor
            {
                R = colorR,
                G = colorG,
                B = colorB
            };  
        }

        var colorTemProperty = jsonProperties.Where(x => x.TryGetProperty("colorTem", out _)).ToList();

        if (colorTemProperty.Any())
        {
            properties.ColorTem = colorTemProperty.First().GetProperty("colorTem").GetInt16();
        }
        
        return properties;
    }
}