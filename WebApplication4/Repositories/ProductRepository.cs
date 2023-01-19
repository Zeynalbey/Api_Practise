using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Database;
using WebApplication4.Database.Model;
using WebApplication4.Interfaces;

namespace WebApplication4.Repositories
{
    
    public class ProductRepository : IProductRepository
    {
        private readonly ProductContext _productContext;

        public ProductRepository(ProductContext productContext)
        {
            _productContext = productContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productContext.Products.AsNoTracking().ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {

             await _productContext.Products.AddAsync(product);
           
            await _productContext.SaveChangesAsync();
            return product;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productContext.Products.AsNoTracking().SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task UpdateAsync(Product product)
        {
            var changed = await _productContext.Products.FindAsync(product.Id);
            _productContext.Entry(changed).CurrentValues.SetValues(product);
            await _productContext.SaveChangesAsync();
        }

        public async Task RemoveAsync(int id)
        {
            var deleted = await _productContext.Products.FindAsync(id);
            _productContext.Products.Remove(deleted);
            await _productContext.SaveChangesAsync();
        }
    }
}
