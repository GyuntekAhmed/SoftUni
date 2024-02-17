namespace PetStore.Services.Data
{
    using Microsoft.EntityFrameworkCore;
    using AutoMapper;

    using PetStore.Data.Common.Repos;
    using PetStore.Data.Models;
    using Mapping;
    using Web.ViewModels.Categories;
    using Interfaces;

    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> repository;
        //private readonly IMapper mapper;

        public CategoryService(IRepository<Category> repository)
        {
            this.repository = repository;
            //this.mapper = mapper;
        }

        public async Task CreateAsync(CreateCategoryInputModel inputModel)
        {
            Category category = AutoMapperConfig.MapperInstance.Map<Category>(inputModel);

            await repository.AddAsync(category);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<AllCategoriesViewModel>> GetAllAsync()
        {
            return await this.repository
                .AllAsNoTracking()
                .To<AllCategoriesViewModel>()
                .ToArrayAsync();
        }
    }
}
