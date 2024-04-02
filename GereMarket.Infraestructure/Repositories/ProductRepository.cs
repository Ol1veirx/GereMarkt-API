using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GereMarket.Infraestructure.Persistence;
using GereMarket.Infraestructure.Repositories.Interfaces;
using GereMarkt.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GereMarket.Infraestructure.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly GereMarketDbContext _context;
        public ProductRepository(GereMarketDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Product>> GetAllProductsAsync()
        {
            var products = await _context.Products.AsNoTracking().ToListAsync();

            return products;
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<Product> CreateProductAsync(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateProductAsync(Product product)
        {
            var updateProduct = await _context.Products.FindAsync(product.Id);

            if(updateProduct == null)
            {
                return null;
            }

            updateProduct.Name = product.Name;
            updateProduct.Price = product.Price;
            updateProduct.Quantity = product.Quantity;
            updateProduct.Supplier = product.Supplier;
            updateProduct.ExpiryDate = product.ExpiryDate;

            await _context.SaveChangesAsync();

            return updateProduct;
        }

        public async Task<bool> DeleteProductAsync(Guid productId)
        {
            var result = await _context.Products.FindAsync(productId);

            if(result == null) 
            { 
                return false; 
            }

            _context.Products.Remove(result);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
