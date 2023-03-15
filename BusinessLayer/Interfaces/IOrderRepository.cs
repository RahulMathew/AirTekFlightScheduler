using BusinessObjects;

namespace BusinessRepository.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrders();
    }
}