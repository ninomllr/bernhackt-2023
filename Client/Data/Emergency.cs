namespace thorstopper.Client.Data;

public class Emergency
{
    public int Id { get; set; }
    public string LocationName { get; set; }
    public int Radius { get; set; }
    public double Lat { get; set; }
    public double Lng { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}