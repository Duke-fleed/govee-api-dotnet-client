namespace GoveeApiClientNet;

public record ApiResponseBase
{
    public string? Message { get; set; }
    public int Code { get; set; }
}