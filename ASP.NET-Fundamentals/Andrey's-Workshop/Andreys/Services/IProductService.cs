namespace Andreys.Services
{
    using Andreys.ViewModels.Products;

    public interface IProductService
    {
        int Add(ProductAddInputModel productAddInputModel);
    }
}
