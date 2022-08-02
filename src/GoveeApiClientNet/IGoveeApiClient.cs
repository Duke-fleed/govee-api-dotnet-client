using GoveeApiClientNet.GetDevices;
using GoveeApiClientNet.GetDeviceState;

namespace GoveeApiClientNet;

public interface IGoveeApiClient
{
    /// <summary>
    /// Gets list of all Govee devices for the user
    /// </summary>
    /// <returns>List of devices</returns>
    public Task<List<Device>> GetDevices();
    /// <summary>
    /// Gets device state for a given device
    /// </summary>
    /// <param name="deviceId">DeviceId identifier of the device</param>
    /// <param name="deviceModel">DeviceModel identifier of the device</param>
    /// <returns>DeviceState object</returns>
    public Task<DeviceState> GetDeviceState(string deviceId, string deviceModel);
    /// <summary>
    /// Turns on the given device
    /// </summary>
    /// <param name="deviceId">DeviceId identifier of the device</param>
    /// <param name="deviceModel">DeviceModel identifier of the device</param>
    public Task TurnOnDevice(string deviceId, string deviceModel);
    /// <summary>
    /// TUrns off the given device
    /// </summary>
    /// <param name="deviceId">DeviceId identifier of the device</param>
    /// <param name="deviceModel">DeviceModel identifier of the device</param>
    public Task TurnOffDevice(string deviceId, string deviceModel);
    /// <summary>
    /// Sets given device light brightness
    /// </summary>
    /// <param name="deviceId">DeviceId identifier of the device</param>
    /// <param name="deviceModel">DeviceModel identifier of the device</param>
    /// <param name="value">Brightness value 0-100</param>
    public Task SetDeviceBrightness(string deviceId, string deviceModel, int value);
    /// <summary>
    /// Sets given device light color
    /// </summary>
    /// <param name="deviceId">DeviceId identifier of the device</param>
    /// <param name="deviceModel">DeviceModel identifier of the device</param>
    /// <param name="color">RGBColor object containing R,G,B values of the color</param>
    public Task SetDeviceColor(string deviceId, string deviceModel, RgbColor color);
    /// <summary>
    /// Sets given device color temperature
    /// </summary>
    /// <param name="deviceId">DeviceId identifier of the device</param>
    /// <param name="deviceModel">DeviceModel identifier of the device</param>
    /// <param name="value">Color temperature value.</param>
    public Task SetDeviceColorTemp(string deviceId, string deviceModel, int value);
}