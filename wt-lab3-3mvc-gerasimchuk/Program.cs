using wt_lab3_3mvc_gerasimchuk.Controllers;

Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("========================================");
Console.WriteLine("   Лабораторная работа WT-3 — MVC");
Console.WriteLine("   Вариант 8: Авиакомпания");
Console.WriteLine("========================================");

var controller = new FlightController();
controller.Run();