namespace SynopsisOfTheNetworks.Mvc.Models;

public class InfoViewModel
{
    public Guid Id { get; init; }
    public string ProtocolName { get; init; } = string.Empty;
    public string? Port { get; init; }
    public string Info { get; init; } = string.Empty;
    public string? Photo { get; init; }
}