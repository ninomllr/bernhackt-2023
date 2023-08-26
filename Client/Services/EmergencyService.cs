using thorstopper.Client.Data;

namespace thorstopper.Client.Services;

public interface IEmergencyService
{
    public Task<IEnumerable<Emergency>> GetEmergency();
}

public class EmergencyService : IEmergencyService
{
    private List<Emergency> _list = new() {
        new Emergency() {Id = 1, LocationName = "Bern", Radius = 3, Lat = 46.998322, Lng = 7.451090, StartDate = 
        DateTime.Today, EndDate = DateTime.Today.AddDays(3)},
        new Emergency() {Id = 1, LocationName = "Belp", Radius = 5, Lat = 46.89139, Lng = 7.49916, StartDate = 
            DateTime.Today, EndDate = DateTime.Today.AddDays(5)},
    };

    public async Task<IEnumerable<Emergency>> GetEmergency()
    {
        return _list;
    }
}
