using Microsoft.JSInterop;

namespace thorstopper.Client.Services;

// Custom leaflet map service for callback
public class LeafletService
{
    public event Func<Task> Notify;
    
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }

    [JSInvokable("GetLatLng")]
    public async Task GetLatLng(double longitude, double latitude)
    {
        Longitude = longitude;
        Latitude = latitude;

        if (Notify != null)
        {
            await Notify?.Invoke()!;
        }
    }
}