namespace GoveeApiClientNet.ControlDevice;

public record struct ControlCommand
{
    public string Name { get; set; }
    public object Value { get; set; }
}