using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace ComponentsLibrary.Map;

public partial class Map
{
    private readonly string elementId = $"map-{Guid.NewGuid():D}";

    [Inject]
    IJSRuntime JSRuntime { get; set; }

    [Parameter]
    public double Zoom { get; set; }
    [Parameter, EditorRequired]
    public List<Marker> Markers { get; set; } = new();

    protected async override Task OnAfterRenderAsync(bool firstRender)
    {
        await JSRuntime.InvokeVoidAsync(
            "stationsMap.showOrUpdate",
            elementId,
            Markers);
    }
}
