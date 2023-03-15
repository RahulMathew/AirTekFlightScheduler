using AirTekApp;
using BusinessRepository.Interfaces;
using Microsoft.Extensions.DependencyInjection;

public class Program
{
    private static IFlightScheduleRepository? _flightScheduleRepository;
    private static IInventoryManagementRepository? _inventoryManagementRepository;

    public Program()
    {
        var dependencyRegistration = new DependencyRegistration();

        var serviceProvider = dependencyRegistration.RegisterDependencies();

        _flightScheduleRepository = serviceProvider.GetService<IFlightScheduleRepository>();

        _inventoryManagementRepository = serviceProvider.GetService<IInventoryManagementRepository>();
    }

    private static async Task DisplayFlightSchedule()
    {
        var schedules = await _flightScheduleRepository!.GetFlightScehdule();

        if (schedules?.Count > 0)
        {
            Console.WriteLine("*************");
            Console.WriteLine("Flight Schedule");
            Console.WriteLine("*************");

            foreach (var schedule in schedules)
            {
                Console.WriteLine($"Flight: {schedule.FlightNumber}, " +
                    $"Departure: {schedule.Departure}, " +
                    $"Arrival: {schedule.Arrival}, " +
                    $"Day: {schedule.Day}");
            }
        }
    }

    private static async Task DisplayItenaries()
    {
        var itenaries = await _inventoryManagementRepository!.GetItenaries();

        if (itenaries?.Count > 0)
        {
            Console.WriteLine("*************");
            Console.WriteLine("Itenaries");
            Console.WriteLine("*************");

            foreach (var intenary in itenaries)
            {
                if(intenary.Schedule != null)
                {
                    Console.WriteLine($"order: {intenary.Code}, " +
                    $"flightNumber: {intenary.Schedule?.FlightNumber}, " +
                    $"departure: {intenary.Schedule?.Departure}, " +
                    $"arrival: {intenary.Schedule?.Arrival}, " +
                    $"day: {intenary.Schedule?.Day}");
                }
                else
                {
                    Console.WriteLine($"order: {intenary.Code}, flightNumber: not scheduled");
                }
            }
        }
    }

    private static Task DisplayMenu()
    {
        Console.WriteLine("*************");
        Console.WriteLine("Air Tek");
        Console.WriteLine("*************");
        Console.WriteLine("1 - View Schedule");
        Console.WriteLine("2 - Generate Flight Itineraries");
        Console.WriteLine("3 - Clear Screen");
        Console.WriteLine("Press Menu Number");

        return Task.CompletedTask;
    }

    public static async Task Main(string[] args)
    {
        Program program = new Program();

        await DisplayMenu();

        ConsoleKeyInfo key;

        do
        {
            key = Console.ReadKey(true);
            
            if (Char.IsNumber(key.KeyChar))
            {
                Int32 menuItem;

                if (Int32.TryParse(key.KeyChar.ToString(), out menuItem))
                {
                    switch (menuItem)
                    {
                        case 1:
                        {
                            await DisplayFlightSchedule();

                            break;
                        }
                        case 2:
                        {
                            await DisplayItenaries();
                            
                            break;
                        }
                        case 3:
                        {
                            Console.Clear();

                            await DisplayMenu();
                        }
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Menu Item");
                }
            }
        }
        while (key.KeyChar != 27);
    }
}