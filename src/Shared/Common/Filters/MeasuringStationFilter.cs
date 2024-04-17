namespace Shared.Common.Filters;

public class MeasuringStationFilter
{
    public string? Name { get; set; } = string.Empty;
    public string? Address { get; set; } = string.Empty;
    public string? Owner { get; set; } = string.Empty;

    public MeasuringStationFilter(string? name, string? address, string? owner)
    {
        Name = name;
        Address = address;
        Owner = owner;
    }
}
