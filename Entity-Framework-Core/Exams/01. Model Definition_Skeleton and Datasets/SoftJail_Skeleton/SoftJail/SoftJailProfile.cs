namespace SoftJail
{
    using AutoMapper;

    using Data.Models;
    using DataProcessor.ImportDto;

    public class SoftJailProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public SoftJailProfile()
        {
            this.CreateMap<ImportDepartmentWithCellsDto, Cell>();
        }
    }
}
