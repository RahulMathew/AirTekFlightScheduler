using BusinessObjects;

namespace BusinessRepository.Interfaces
{
    public interface IFlightScheduleRepository
    {
        Task<List<Schedule>> GetFlightScehdule();
    }
}