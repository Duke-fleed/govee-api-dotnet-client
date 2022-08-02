# Govee API .NET client

The Govee API .NET client is a lightweight class library to consume Govee developer API V1.8. It provides common services for making API requests.

![build and publish](https://github.com/Duke-fleed/govee-api-dotnet-client/actions/workflows/package.yml/badge.svg)
[![Nuget](https://img.shields.io/nuget/v/GoveeApiClient?cacheSeconds=50)](https://www.nuget.org/packages/GoveeApiClient/)

### Requirements

* .NET 6
* C# language version - 10.0+

### Usage examples

Instantiate a client

```C#

IGoveeApiClient goveeApiClient = new GoveeApiClient("<developer API key here>");
```

Get devices
```C#
var devices = await goveeApiClient.GetDevices();
```

Get device state
```C#
var deviceState = await goveeApiClient.GetDeviceState("DeviceId","DeviceModel");
```

Turn on/off device
```C#
await goveeApiClient.TurnOnDevice("DeviceId","DeviceModel");
await goveeApiClient.TurnOffDevice("DeviceId","DeviceModel");
```

Set device brightness to 100%
```C#
await goveeApiClient.SetDeviceBrightness("DeviceId","DeviceModel", 100);
```

Set device color to red
```C#
var color = new RgbColor
{
    R = 255,
    G = 0,
    B = 0
};
await goveeApiClient.SetDeviceColor("DeviceId","DeviceModel", color);
```

Set device color temp to 2000
```C#
await goveeApiClient.SetDeviceColorTemp("DeviceId","DeviceModel", 2000);
```

### Seeking Assistance
If you find any problems or would like to suggest a feature, please feel free to file an issue on Github at [Issues Page](https://github.com/Duke-fleed/govee-api-dotnet-client/issues).