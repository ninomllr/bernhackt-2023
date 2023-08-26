using thorstopper.Client.Data;

namespace thorstopper.Client.Services;



public interface ICaseService
{
	public Task<IEnumerable<Case>> GetCases();
}

public class CaseService : ICaseService
{
	private List<Case> _list = new() {
		new Case() { CaseNumber = 1, CaseName = "Sturmwind Schaden Dach & Fassade", Address = "Weg 1, 3007 Bern", Lat = 46.941560, Lng = 7.425820,
			CustomerName = "Tom Tommasson", Date = DateTime.Now, Bounty = null},
		new Case() { CaseNumber = 2, CaseName = "Sturmschäden Dach & Kamin", Address = "Kapellenstrasse 26, 3011 Bern", Lat = 46.945420,
			Lng = 7.433950, CustomerName ="Peter Musterman", Date = DateTime.Now, Bounty = null},
		new Case() { CaseNumber = 3, CaseName = "S Dach hets glupft", Address = "Lindenhofstrasse 1, 3048 Ittigen", Lat = 46.979641,
			Lng = 7.460920, CustomerName = "Hans Muster", Date = DateTime.Now, Bounty = true},
	};

	public async Task<IEnumerable<Case>> GetCases()
	{
		return _list;
	}
}