using BusinessObjects;
using BusinessRepository.Interfaces;

namespace BusinessRepository.Core
{
    public class InventoryManagementRepository : IInventoryManagementRepository
    {
        private readonly IFlightScheduleRepository _flightScheduleRepository;
        private readonly IOrderRepository _orderRepository;

        public List<Order>? Orders { get; private set; }
        public List<Flight>? FlightsScheduled { get; private set; }
        public List<Schedule>? Schedules { get; private set; }

        public InventoryManagementRepository(IFlightScheduleRepository flightScheduleRepository, IOrderRepository orderRepository)
        {
            _flightScheduleRepository = flightScheduleRepository;
            _orderRepository = orderRepository;
            FlightsScheduled = new List<Flight>();

            Initialize();
        }

        private async void Initialize()
        {
            Schedules = await _flightScheduleRepository.GetFlightScehdule();
            Orders = await _orderRepository.GetOrders();
        }

        public async Task<List<Order>> GetItenaries()
        {
            await ProcessFlightSchedule();

            await LoadOrdersInFlights();

            return Orders!;
        }

        private Task ProcessFlightSchedule()
        {
            foreach(var schedule in Schedules!)
            {
                if (!schedule.IsLoaded)
                {
                    var scheduledFlight = new Flight(20, schedule);

                    FlightsScheduled!.Add(scheduledFlight);

                    FlightsScheduled = FlightsScheduled.OrderBy(f => f.Schedule.FlightNumber).ToList();
                }
            }

            return Task.CompletedTask;
        }

        private Task LoadOrdersInFlights()
        {
            Orders = Orders!.OrderBy(o => o.Priority).ToList();

            foreach (var schedule in Schedules!)
            {
                if (schedule.IsLoaded)
                {
                    var loadedFlights = FlightsScheduled!.Where(f => f.Schedule == schedule).ToList();

                    foreach (var flight in loadedFlights)
                    {
                        var flightOrders = Orders!.Where(o => o.IsNotLoaded() 
                            && o.Destination == schedule.Arrival)
                            .Take(flight.Capacity).Select(o => { 
                                o.Schedule = schedule; 
                                return o; 
                            }).ToList();
                        
                        flight.Orders = flightOrders;
                    }
                }
            }

            return Task.CompletedTask;
        }
    }
}
