using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using GoveeApiClientNet.ControlDevice;
using GoveeApiClientNet.GetDevices;
using GoveeApiClientNet.GetDeviceState;

namespace GoveeApiClientNet;

public class GoveeApiClient : IGoveeApiClient
{
    private const string GoveeApiKeyHeaderName = "Govee-API-Key";
    private const string GoveeApiHost = "https://developer-api.govee.com/v1/";
    private readonly HttpClient httpClient;

    private readonly JsonSerializerOptions? jsonOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
    
    public GoveeApiClient(string apiKey, HttpClient? httpClient = null)
    {
        this.httpClient = httpClient ?? new HttpClient();
        this.httpClient.DefaultRequestHeaders.Add(GoveeApiKeyHeaderName, apiKey);
    }
    
    public async Task<List<Device>> GetDevices()
    {
        var response = await httpClient.GetFromJsonAsync<DevicesResponse>($"{GoveeApiHost}devices");
        if (response?.Code == 200)
        {
            return response.Data.Devices;
        } 
        throw new Exception($"Request failed. Status code: {response?.Code}, Message: {response?.Message}");
    }

    public async Task TurnOnDevice(string deviceId, string deviceModel) => await SetDeviceState(deviceId, deviceModel, "turn", "on");
        
    public async Task TurnOffDevice(string deviceId, string deviceModel) => await SetDeviceState(deviceId, deviceModel, "turn", "off");
        
    public async Task SetDeviceBrightness(string deviceId, string deviceModel, int value) => await SetDeviceState(deviceId, deviceModel, "brightness", value);

    public async Task SetDeviceColor(string deviceId, string deviceModel, RgbColor color) => await SetDeviceState(deviceId, deviceModel, "color", color);

    public async Task SetDeviceColorTemp(string deviceId, string deviceModel, int value) => await SetDeviceState(deviceId, deviceModel, "colorTem", value);

    public async Task<DeviceState> GetDeviceState(string deviceId, string deviceModel)
    {
        var jsonResponse = await httpClient.GetStringAsync(
            $"{GoveeApiHost}devices/state?device={deviceId}&model={deviceModel}");
        var deserialized = JsonSerializer.Deserialize<DeviceStateResponse>(jsonResponse,jsonOptions);

        if (deserialized?.Code != 200)
            throw new Exception($"Request failed. Status code: {deserialized?.Code}, Message: {deserialized?.Message}");
        
        deserialized.Data.Properties = DeserializeHelper.DeserializeProperties(jsonResponse);
        
        return deserialized.Data;
    }

    private async Task SetDeviceState(string deviceId, string deviceModel, string commandName, object commandValue)
    {
        var request = new ControlRequest
        {
            Device = deviceId,
            Model = deviceModel,
            Cmd = new ControlCommand
            {
                Name = commandName,
                Value = commandValue
            }
        };
        
        var responseJson = await httpClient.PutAsync(
            $"{GoveeApiHost}devices/control",
            new StringContent(JsonSerializer.Serialize(request, jsonOptions), Encoding.UTF8, "application/json"));
            
        var response = JsonSerializer.Deserialize<ApiResponseBase>(await responseJson.Content.ReadAsStringAsync(), jsonOptions);
        if (response?.Code != 200)
            throw new Exception($"Request failed. Status code: {response?.Code}, Message: {response?.Message}");
    }
}