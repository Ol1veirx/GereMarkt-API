using GereMarket.Application.Services.Interfaces;
using GereMarkt.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GereMarkt.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _service;
        public ProductController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                var products = await _service.GetAllProductsAsync();

                return Ok(products);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpGet("{productName}")]
        public async Task<IActionResult> GetProductByName(string productName)
        {
            try
            {
                var product = await _service.GetProductByNameAsync(productName);

                return Ok(product);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProdutc(Product product)
        {
            try
            {
                var newProduct = await _service.CreateProductAsync(product);

                return CreatedAtAction(nameof(GetProductByName), new { productName = newProduct.Name }, newProduct);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{productId}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, Product product)
        {
            if (productId != product.Id)
            {
                return NotFound();
            }

            try
            {
                var updateProduct = await _service.UpdateProductAsync(product);

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            try
            {
                var result = await _service.DeleteProductAsync(productId);

                if (!result)
                {
                    return NotFound();
                }

                return NoContent();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
