using OrderService.Models;

namespace OrderService.Repositories.Abstract
{
    public interface IOrderServ
    {
        Task<IEnumerable<Order>> GetOrdersAsync();
        Task<Order> GetOrderAsync(int id);
        Task CreateOrderAsync(Order order);
        Task UpdateOrderAsync(int id,Order order);
        Task DeleteOrderAsync(int id);
    }
}
