using ASPNETCoreDatabases.Core.Contracts;
using ASPNETCoreDatabases.Core.Models;
using ASPNETCoreDatabases.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreDatabases.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly WebShopDbContext _dbContext;
        public ProductService(WebShopDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task AddProductAsync(ProductFormModel model)
        {
            Product product = new Product
            {
                ProductName = model.Name,
                Quantity = model.Quantity
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<ProductViewModel>> GetProductsAsync()
        {
            return await _dbContext.Products
                .Select(p => new ProductViewModel
                {
                    Id = p.Id,
                    Name = p.ProductName
                })
                .ToListAsync();
        }
    }
}
