using BusinessObjects;

namespace BusinessRepository.Interfaces
{
    public interface IInventoryManagementRepository
    {
        Task<List<Order>> GetItenaries();
    }
}