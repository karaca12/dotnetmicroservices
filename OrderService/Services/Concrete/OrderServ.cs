using Microsoft.EntityFrameworkCore;
using OrderService.Clients.Abstract;
using OrderService.Data;
using OrderService.Models;
using OrderService.Repositories.Abstract;
using System.Text.Json;

namespace OrderService.Repositories.Concrete
{
    public class OrderServ : IOrderServ
    {
        private readonly IOrderRepository _repository;
        private readonly IProductClient _productClient;

        public OrderServ(IOrderRepository repository,IProductClient productClient)
        {
            _repository = repository;
            _productClient = productClient;

        }

        public async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            return await _repository.GetOrdersAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            var order = await _repository.GetOrderAsync(id);
            if (order == null) {
                throw new BadHttpRequestException("Couldn't find the order.");
            }
            return order;
        }

        public async Task CreateOrderAsync(Order order)
        {
            var productPrice=await _productClient.GetProductPriceByIdAsync(order.ProductId);
            order.TotalPrice = productPrice * order.Quantity;
            await _repository.CreateOrderAsync(order);
        }

        public async Task UpdateOrderAsync(int id, Order order)
        {
            if (id != order.Id)
            {
                throw new BadHttpRequestException("Id's dont match.");
            }
            await _repository.UpdateOrderAsync(order);
        }

        public async Task DeleteOrderAsync(int id)
        {
            await _repository.DeleteOrderAsync(id);
        }

        
    }
}
