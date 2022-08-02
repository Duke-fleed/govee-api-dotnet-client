namespace GoveeApiClientNet.ControlDevice;

public record struct ControlRequest
{
    public string Device { get; set; }
    public string Model { get; set; }
    public ControlCommand Cmd { get; set; }
}