using System.Collections;
using System;
namespace thorstopper.Client.Data;

public class Offer
{
	public int OfferNumber { get; set; }
	public IEnumerable<string> OfferDescription { get; set; } = new List<string>();
	public DateTime OfferDate { get; set; }
	public DateTime DeliveryDate { get; set; }
	public string ServiceProviderName { get; set; }
	public string ServiceProviderAddress { get; set; }
	public int OfferPrice { get; set; }
	public int BountyPrice { get; set; }
}