using ASPNETCoreDatabases.Core.Models;

namespace ASPNETCoreDatabases.Core.Contracts
{
    public interface IProductService
    {
        Task<List<ProductViewModel>> GetProductsAsync();

        Task AddProductAsync(ProductFormModel model);
    }
}
