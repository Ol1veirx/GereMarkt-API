using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GereMarket.Application.Services.Interfaces;
using GereMarket.Infraestructure.Repositories.Interfaces;
using GereMarkt.Core.Entities;
using Microsoft.Extensions.Logging;

namespace GereMarket.Application.Services.Implementations
{
    public class ProductService : IProductService
    {

        private readonly IProductRepository _repository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IProductRepository repository, ILogger<ProductService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            try
            {
                _logger.LogInformation("GetAllProductsAsync call");

                return await _repository.GetAllProductsAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error:");
                throw;
            }
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            try
            {
                _logger.LogInformation("GetProductByNameAsync call");

                return await _repository.GetProductByNameAsync(productName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error: ");
                throw;
            }
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            try
            {
                _logger.LogInformation("CreateProductAsync call");

                return await _repository.CreateProductAsync(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error");
                throw;
            }
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            try
            {
                _logger.LogInformation("UpdateProductAsync call");

                return await _repository.UpdateProductAsync(product);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error:");
                throw;
            }
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            try
            {
                _logger.LogInformation("DeleteProductAsync call");

                return await _repository.DeleteProductAsync(productId);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error");
                throw;
            }
        }

    }
}
