using wt_lab3_3mvc_gerasimchuk.Models;
using wt_lab3_3mvc_gerasimchuk.Views;

namespace wt_lab3_3mvc_gerasimchuk.Controllers;

public class FlightController
{
    private readonly List<Flight> flights;
    private readonly FlightView view;

    public FlightController()
    {
        flights = new List<Flight>
        {
            new Flight { Id = 1, FlightNumber = "MSQ-WAW", DepartureCity = "Минск",   ArrivalCity = "Варшава", Price = 250, IsAvailable = true  },
            new Flight { Id = 2, FlightNumber = "MSQ-BER", DepartureCity = "Минск",   ArrivalCity = "Берлин",  Price = 410, IsAvailable = true  },
            new Flight { Id = 3, FlightNumber = "WAW-BER", DepartureCity = "Варшава", ArrivalCity = "Берлин",  Price = 320, IsAvailable = false }
        };
        view = new FlightView();
    }

    public void Index()
    {
        view.ShowFlights(flights);
    }

    public void Show(int id)
    {
        var flight = flights.FirstOrDefault(f => f.Id == id);

        if (flight == null)
        {
            view.ShowMessage("Рейс не найден.");
            return;
        }

        view.ShowFlight(flight);
    }

    public void Add(Flight flight)
    {
        flights.Add(flight);
        view.ShowMessage("Рейс успешно добавлен.");
    }

    public void Delete(int id)
    {
        var flight = flights.FirstOrDefault(f => f.Id == id);

        if (flight == null)
        {
            view.ShowMessage("Рейс не найден.");
            return;
        }

        flights.Remove(flight);
        view.ShowMessage("Рейс успешно удалён.");
    }

    // Дополнительная операция
    public void SearchByCity(string city)
    {
        var result = flights
            .Where(f => f.ArrivalCity.Contains(city, StringComparison.OrdinalIgnoreCase)
                     || f.DepartureCity.Contains(city, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (result.Count == 0)
        {
            view.ShowMessage($"Рейсы в город '{city}' не найдены.");
            return;
        }

        view.ShowFlights(result);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать рейсы");
            Console.WriteLine("2. Найти рейс по ID");
            Console.WriteLine("3. Добавить рейс");
            Console.WriteLine("4. Удалить рейс");
            Console.WriteLine("5. Поиск по городу");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowFlightByUserInput(); break;
                case "3": AddFlightByUserInput(); break;
                case "4": DeleteFlightByUserInput(); break;
                case "5": SearchByCityByUserInput(); break;
                case "0": return;
                default:
                    view.ShowMessage("Неизвестная команда.");
                    break;
            }
        }
    }

    private void ShowFlightByUserInput()
    {
        Console.Write("Введите ID рейса: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddFlightByUserInput()
    {
        Console.Write("Номер рейса: ");
        var number = Console.ReadLine() ?? "";

        Console.Write("Город вылета: ");
        var from = Console.ReadLine() ?? "";

        Console.Write("Город прилёта: ");
        var to = Console.ReadLine() ?? "";

        Console.Write("Цена: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            view.ShowMessage("Некорректная цена.");
            return;
        }

        Console.Write("Доступен (1 — да, 0 — нет): ");
        var availableInput = Console.ReadLine();
        bool isAvailable = availableInput == "1";

        int newId = flights.Count == 0 ? 1 : flights.Max(f => f.Id) + 1;

        var flight = new Flight
        {
            Id = newId,
            FlightNumber = number,
            DepartureCity = from,
            ArrivalCity = to,
            Price = price,
            IsAvailable = isAvailable
        };

        Add(flight);
    }

    private void DeleteFlightByUserInput()
    {
        Console.Write("Введите ID рейса для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }

    private void SearchByCityByUserInput()
    {
        Console.Write("Введите город: ");
        var city = Console.ReadLine() ?? "";
        SearchByCity(city);
    }
}