using BusinessObjects;
using BusinessRepository.Interfaces;
using Newtonsoft.Json;

namespace BusinessRepository.Core
{
    public class OrderRepository : IOrderRepository
    {
        private readonly string? _orderJSONFile;

        public OrderRepository()
        {
            _orderJSONFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "coding-assigment-orders.json");
        }

        public Task<List<Order>> GetOrders()
        {
            List<Order> orders = new List<Order>();

            if (!string.IsNullOrWhiteSpace(_orderJSONFile))
            {
                using (StreamReader r = new StreamReader(_orderJSONFile))
                {
                    string json = r.ReadToEnd();

                    if (!string.IsNullOrWhiteSpace(json))
                    {
                        orders = JsonConvert.DeserializeObject<Dictionary<string, Order>>(json).Select(p =>
                        new Order
                        {
                            Code = p.Key,
                            Destination = p.Value.Destination,
                            Priority = Int32.Parse(p.Key.Substring(p.Key.LastIndexOf('-') + 1))
                        }).ToList();
                    }
                }
            }

            return Task.FromResult(orders);
        }
    }
}
