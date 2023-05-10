namespace Andreys.Controllers
{
    using ViewModels.Products;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProductsController : Controller
    {
        public HttpResponse Add()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(ProductAddInputModel inputModel)
        {
            return this.View();
        }
    }
}
