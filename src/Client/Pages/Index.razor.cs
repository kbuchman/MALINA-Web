using Client.Repositories;
using ComponentsLibrary.Map;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Radzen;
using Radzen.Blazor;
using Shared.Common.Filters;

namespace Client.Pages;

public partial class Index
{
    private double zoom = 12;
    private List<Marker> markers = new List<Marker>
    {
        new Marker()
        {
            Y = 50.06471149903141,
            X = 19.919907970254478,
            Name = "Name",
            Description = "Description",
        }
    };

    [Inject]
    DialogService DialogService { get; set; }

    private async Task OnSearchMeasuringStations(MeasuringStationFilter filter)
    {
        var stations = await APIHandler.GetMeasuringStationsByParams(filter);

        markers = stations.Select(s => new Marker()
        {
            Y = double.Parse(s.Location.Coordinates.Split(',')[0]),
            X = double.Parse(s.Location.Coordinates.Split(',')[1]),
            Description = s.Id.ToString(),
        }).ToList();
    }

    [JSInvokable]
    public static void ReturnMarkerPopupOpen(Marker marker)
    {
        var mar = marker;
    }

    private async Task OnMarkerClick(Guid guid)
    {

    }
}
