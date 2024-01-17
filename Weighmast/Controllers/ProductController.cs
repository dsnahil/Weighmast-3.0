using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Weighmast.Data;
using Weighmast.Models;

namespace Weighmast.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly WeighmastContext _context;
        public ProductController(WeighmastContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Products.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);

            if (Product == null)
            {
                return NotFound();
            }
            return Product;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<Product>>> AddProduct(Product Product)
        {
            _context.Products.Add(Product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = Product.ProductId }, Product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var Product = await _context.Products.FindAsync(id);
            if (Product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPatch("product/{id}/activate")]
        public async Task<ActionResult<Product>> ActivateProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            product.IsActive = 1;
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpPatch("product/{id}/deactivate")]
        public async Task<ActionResult<Product>> DeactivateProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound("Product not found");
            }

            product.IsActive = 0;
            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(p => p.ProductId == id);
        }
    }
}