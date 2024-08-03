namespace OrderService.Clients.Abstract
{
    public interface IProductClient
    {
        Task<decimal> GetProductPriceByIdAsync(int productId);
    }
}
