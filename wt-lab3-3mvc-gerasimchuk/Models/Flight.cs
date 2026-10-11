namespace wt_lab3_3mvc_gerasimchuk.Models;

public class Flight
{
    public int Id { get; set; }
    public string FlightNumber { get; set; } = "";
    public string DepartureCity { get; set; } = "";
    public string ArrivalCity { get; set; } = "";
    public decimal Price { get; set; }
    public bool IsAvailable { get; set; }
}