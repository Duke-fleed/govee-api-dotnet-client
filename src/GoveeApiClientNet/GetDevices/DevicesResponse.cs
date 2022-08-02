namespace GoveeApiClientNet.GetDevices;

public record DevicesResponse : ApiResponseBase
{
    public Data Data { get; set; }
}