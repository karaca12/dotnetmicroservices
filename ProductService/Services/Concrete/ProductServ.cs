using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProductService.Models;
using ProductService.Repositories.Abstract;
using ProductService.Services.Abstract;
using System.Net.Sockets;

namespace ProductService.Services.Concrete
{
    public class ProductServ : IProductServ
    {
        private readonly IProductRepository _repository;

        public ProductServ(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateProductAsync(Product product)
        {
            await _repository.CreateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _repository.DeleteProductAsync(id);
        }

        public async Task<ActionResult<decimal>> GetPriceById(int id)
        {
            var product = await GetProductAsync(id);
            return product.Price;
        }

        public async Task<Product> GetProductAsync(int id)
        {
            var product = await _repository.GetProductAsync(id);
            if (product == null) {
                throw new BadHttpRequestException("Couldn't find the product.");
            }
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _repository.GetProductsAsync();
        }

        public async Task UpdateProductAsync(int id,Product product)
        {
            if (id != product.Id)
            {
                throw new BadHttpRequestException("Id's dont match.");
            }
            await _repository.UpdateProductAsync(product);
        }
    }
}
