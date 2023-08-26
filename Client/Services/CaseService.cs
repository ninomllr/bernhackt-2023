using thorstopper.Client.Data;

namespace thorstopper.Client.Services;



public interface ICaseService
{
	public Task<IEnumerable<Case>> GetCases();
}

public class CaseService : ICaseService
{
	private List<Case> _list;

	public CaseService()
	{
		_list = new List<Case>() {
			new Case() { CaseNumber = 1, CaseName = "Test 1", Address = "Weg 1, 3007 Bern", Lat = 46.941560, Lng = 7.425820, CustomerName = "Tom Tommasson", Date = DateTime.Now, Bounty = true},
			new Case() { CaseNumber = 1, CaseName = "Test 2", Address = "Kapellenstrasse 26, 3011 Bern", Lat = 46.945420, Lng = 7.433950, CustomerName ="Peter Musterman", Date = DateTime.Now, Bounty = false},
			new Case() { CaseNumber = 1, CaseName = "Test 2", Address = "Lindenhofstrasse 1, 3048 Ittigen", Lat = 46.979641, Lng = 7.460920, CustomerName = "Hans Muster", Date = DateTime.Now, Bounty = true},
		};
	}
	public async Task<IEnumerable<Case>> GetCases()
	{
		return _list;
	}
}