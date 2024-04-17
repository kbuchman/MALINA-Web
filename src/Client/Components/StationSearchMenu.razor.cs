using Microsoft.AspNetCore.Components;
using Shared.Common.Filters;

namespace Client.Components;

public partial class StationSearchMenu
{
    private string? name;
    private string? address;
    private string? owner;

    [Parameter]
    public EventCallback<MeasuringStationFilter> OnDisplayButtonClicked { get; set; }

    private async Task OnClick()
    {
        var filters = new MeasuringStationFilter(name, address, owner);
        await OnDisplayButtonClicked.InvokeAsync(filters);
    }
}
