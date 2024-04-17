using Shared.Common.Filters;
using Shared.Models.MeasuringStation;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace Client.Repositories;

public static class APIHandler
{
    private static readonly HttpClient httpClient = new();
    private const string host = "https://localhost:44357/";

    public static async Task<List<MeasuringStationListView>> GetMeasuringStationsByParams(MeasuringStationFilter filter)
    {
        httpClient.BaseAddress = new Uri(host);
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        const string getMeasuringStationList = "malinaApi/MeasuringStation/get-all-by-params?";

        var stringBuilder = new StringBuilder(getMeasuringStationList);

        if (!string.IsNullOrEmpty(filter.Name))
        {
            stringBuilder.Append($"name={filter.Name}");
        }
        if (!string.IsNullOrEmpty(filter.Address))
        {
            stringBuilder.Append(stringBuilder.Length == getMeasuringStationList.Length
                ? $"address={filter.Address}" : $"&address={filter.Address}");
        }
        if (!string.IsNullOrEmpty(filter.Owner))
        {
            stringBuilder.Append(stringBuilder.Length == getMeasuringStationList.Length
                ? $"owner={filter.Owner}" : $"&owner={filter.Owner}");
        }

        List<MeasuringStationListView> stationListViews = new();
        try
        {
            HttpResponseMessage response = 
                await httpClient.GetAsync(stringBuilder.ToString());
            if (response.IsSuccessStatusCode)
            {
                stationListViews = await response.Content.ReadFromJsonAsync<List<MeasuringStationListView>>() ?? new();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return stationListViews;
    }
}
