using thorstopper.Client.Data;

namespace thorstopper.Client.Services;



public interface IOfferService
{
	public Task<IEnumerable<Offer>> GetOffers();
}

public class OfferService : IOfferService
{
	private List<Offer> _list = new() {
		new Offer() {
			OfferNumber = 1,
			OfferDescription = new List<string>() {
				"Neugestaltung Fassade",
				"Reparatur Dach"
			},
			ServiceProviderName = "Handwerker Michu",
			ServiceProviderAddress = "Steffisweg 27, 3612 Steffisburg",
			OfferPrice = 40000,
			BountyPrice = 1000
		},
		new Offer() {
			OfferNumber = 1,
			OfferDescription = new List<string>() {
				"Neugestaltung Fassade",
				"Reparatur Dach"
			},
			ServiceProviderName = "Handwerker Brüder Dacherinno",
			ServiceProviderAddress = "Strassi McStrassistrass 43, 3012 Bern",
			OfferPrice = 460000,
		},
		new Offer() {
			OfferNumber = 3,
			OfferDescription = new List<string>() {
				"Neugestaltung Fassade",
				"Reparatur Dach",
				"Qualitätsprüfung",
				"Fahrpauschale"
			},
			ServiceProviderName = "Dachdecker Tom",
			ServiceProviderAddress = "Handwerkergasse 17, 3007 Bern",
			OfferPrice = 47000,
		},
	};

	public async Task<IEnumerable<Offer>> GetOffers()
	{
		return _list;
	}
}