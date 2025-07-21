using AutoMapper;
using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;

namespace ElectronicStore.API.Mapping
{
    public class ProductMapping : Profile
    {
        public ProductMapping()
        {
            CreateMap<Product,ProductDTO>().ForMember(x=>x.CategoryName,op=>op.MapFrom(src=>src.Category.Name)).ReverseMap();
            CreateMap<Photo, PhotoDTO>().ReverseMap();
            CreateMap<AddProductDTO, Product>().ForMember(m => m.Photos, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}
