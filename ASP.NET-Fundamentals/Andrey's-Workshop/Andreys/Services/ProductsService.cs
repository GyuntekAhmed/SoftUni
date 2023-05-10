﻿namespace Andreys.Services
{
    using Andreys.Data;
    using Andreys.Models;
    using System;

    using ViewModels.Products;

    public class ProductsService : IProductService
    {
        private readonly AndreysDbContext dbContext;

        public ProductsService(AndreysDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(ProductAddInputModel productAddInputModel)
        {
            var genderAsEnum = Enum.Parse<Gender>(productAddInputModel.Gender);
            var categoryAsEnum = Enum.Parse<Category>(productAddInputModel.Category);

            var product = new Product()
            {
                Name = productAddInputModel.Name,
                Description = productAddInputModel.Description,
                ImageUrl = productAddInputModel.ImageUrl,
                Price = productAddInputModel.Price,
                Gender = genderAsEnum,
                Category = categoryAsEnum
            };

            this.dbContext.Products.Add(product);
            this.dbContext.SaveChanges();

            return product.Id;
        }
    }
}
