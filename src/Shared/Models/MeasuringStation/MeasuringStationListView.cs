using Shared.Models.Common;

namespace Shared.Models.MeasuringStation;

public class MeasuringStationListView
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Location Location { get; set; } = new Location();
}
