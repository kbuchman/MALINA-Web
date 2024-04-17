namespace Shared.Models.Common;

public class Location
{
    public string Coordinates { get; set; } = string.Empty;
    public DateTimeKind DateTimeKind { get; set; } = DateTimeKind.Utc;
    public virtual Address Address { get; set; } = new Address();
}
