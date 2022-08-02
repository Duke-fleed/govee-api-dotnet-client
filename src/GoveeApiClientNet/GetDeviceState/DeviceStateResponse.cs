namespace GoveeApiClientNet.GetDeviceState;

public record DeviceStateResponse : ApiResponseBase
{
    public DeviceState Data { get; set; }
}