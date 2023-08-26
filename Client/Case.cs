using System;
namespace thorstopper.Client;

public class Case
{
	public int CaseNumber { get; set; }
	public string CaseName { get; set; }
	public DateTime Date { get; set; }
	public string CustomerName { get; set; }

	public string Address { get; set; }
}