using BusinessObjects;
using BusinessRepository.Interfaces;

namespace BusinessRepository.Core
{
    public class FlightScheduleRepository : IFlightScheduleRepository
    {
        public Task<List<Schedule>> GetFlightScehdule()
        {
            List<Schedule> schedules = new List<Schedule>()
            {
                new Schedule()
                {
                    FlightNumber = 1,
                    Day = 1,
                    Departure = "YUL",
                    Arrival = "YYZ"
                },
                new Schedule()
                {
                   FlightNumber = 2,
                    Day = 1,
                    Departure = "YUL",
                    Arrival = "YYC"
                },
                new Schedule()
                {
                    FlightNumber = 3,
                    Day = 1, 
                    Departure = "YUL", 
                    Arrival = "YVR"
                },
                new Schedule()
                {
                    FlightNumber = 4,
                    Day = 2,
                    Departure = "YUL",
                    Arrival = "YYZ"
                },
                new Schedule()
                {
                    FlightNumber = 5,
                    Day = 2, 
                    Departure = "YUL", 
                    Arrival = "YYC"
                },
                new Schedule()
                {
                    FlightNumber = 6,
                    Day = 2, 
                    Departure = "YUL", 
                    Arrival = "YVR"
                }
            };

            return Task.FromResult(schedules);
        }
    }
}