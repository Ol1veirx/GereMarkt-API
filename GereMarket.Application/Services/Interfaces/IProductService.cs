using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GereMarkt.Core.Entities;

namespace GereMarket.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAllProductsAsync();
        Task<Product> GetProductByNameAsync(string productName);
        Task<Product> CreateProductAsync(Product product);
        Task<Product> UpdateProductAsync(Product product);
        Task<bool> DeleteProductAsync(Guid productId);
    }
}
