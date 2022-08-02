namespace GoveeApiClientNet.GetDeviceState;

public record Properties
{
    public bool Online { get; set; }
    public PowerState PowerState { get; set; }
    public int Brightness { get; set; }
    public int? ColorTem { get; set; }
    public RgbColor Color { get; set; }
}