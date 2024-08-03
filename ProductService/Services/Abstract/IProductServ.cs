using Microsoft.AspNetCore.Mvc;
using ProductService.Models;

namespace ProductService.Services.Abstract
{
    public interface IProductServ
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductAsync(int id);
        Task CreateProductAsync(Product product);
        Task UpdateProductAsync(int id,Product product);
        Task DeleteProductAsync(int id);
        Task<ActionResult<decimal>> GetPriceById(int id);
    }
}
