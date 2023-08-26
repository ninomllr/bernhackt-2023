using System;
namespace thorstopper.Client.Data;

public class Case
{
	public int CaseNumber { get; set; }
	public string CaseName { get; set; }
	public DateTime Date { get; set; }
	public string CustomerName { get; set; }

	public string Address { get; set; }

	public double Lat { get; set; }
	public double Lng { get; set; }

	public bool? Bounty { get; set; }
}