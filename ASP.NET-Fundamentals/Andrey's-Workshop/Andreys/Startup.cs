namespace Andreys.App
{
    using System.Collections.Generic;

    using Data;
    using Services;

    using SIS.HTTP;
    using SIS.MvcFramework;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            using (var db = new AndreysDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService,UsersService>();
            serviceCollection.Add<IProductService,ProductsService>();
        }
    }
}
