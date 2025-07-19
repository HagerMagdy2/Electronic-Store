using AutoMapper;
using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;

namespace ElectronicStore.API.Mapping
{
    public class CategoryMapping:Profile
    {
        public CategoryMapping()
        {
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<UpdateCategoryDTO, Category>().ReverseMap();
        }
    }
    
    
}
