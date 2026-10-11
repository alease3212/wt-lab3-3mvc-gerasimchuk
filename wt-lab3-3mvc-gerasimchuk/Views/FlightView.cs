using wt_lab3_3mvc_gerasimchuk.Models;

namespace wt_lab3_3mvc_gerasimchuk.Views;

public class FlightView
{
    public void ShowFlights(List<Flight> flights)
    {
        Console.WriteLine("=== СПИСОК РЕЙСОВ ===");

        if (flights.Count == 0)
        {
            Console.WriteLine("(список пуст)");
            return;
        }

        foreach (var f in flights)
        {
            Console.WriteLine(
                $"{f.Id}. {f.FlightNumber} | " +
                $"{f.DepartureCity} → {f.ArrivalCity} | " +
                $"{f.Price} руб. | " +
                $"Доступен: {(f.IsAvailable ? "Да" : "Нет")}"
            );
        }
    }

    public void ShowFlight(Flight f)
    {
        Console.WriteLine("=== РЕЙС ===");
        Console.WriteLine($"ID:          {f.Id}");
        Console.WriteLine($"Номер:       {f.FlightNumber}");
        Console.WriteLine($"Откуда:      {f.DepartureCity}");
        Console.WriteLine($"Куда:        {f.ArrivalCity}");
        Console.WriteLine($"Цена:        {f.Price} руб.");
        Console.WriteLine($"Доступен:    {(f.IsAvailable ? "Да" : "Нет")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine($">> {message}");
    }
}