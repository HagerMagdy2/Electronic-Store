using AutoMapper;
using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;
using ElectronicStore.Core.Interfaces;
using ElectronicStore.Core.Services;
using ElectronicStore.infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.infrastructure.Repositries
{
    public class ProductRepositry : GenericRepositry<Product>, IProductRepositry
    {

        private readonly IMapper mapper;
        private readonly AppDbContext context;
        private readonly IImageManagementService imageManagementService;

        public ProductRepositry(AppDbContext context, IMapper mapper, IImageManagementService imageManagementService) : base(context)
        {
            this.mapper = mapper;
            this.context = context;
            this.imageManagementService = imageManagementService;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;

            var product = mapper.Map<Product>(productDTO);

            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();

            var ImagePath = await imageManagementService.AddImageAsync(productDTO.Photo, productDTO.Name);

            var photo = ImagePath.Select(path => new Photo
            {
                ImageName = path,
                ProductId = product.Id,
            }).ToList();
            await context.Photos.AddRangeAsync(photo);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(UpdateProductDTO updateproductDTO)
        {
            if (updateproductDTO == null)
            {
                return false;
            }
            else
            {
                var FindProduct = await context.Products.Include(p => p.Category).Include(p => p.Photos)
                                                        .FirstOrDefaultAsync(p => p.Id == updateproductDTO.Id);
                if (FindProduct == null)
                {
                    return false;
                }
               mapper.Map(updateproductDTO,FindProduct);
                var findphoto = await context.Photos.Where(p => p.ProductId == updateproductDTO.Id).ToListAsync();
                foreach (var photo in findphoto)
                {
                    imageManagementService.DeleteImageAsync(photo.ImageName);
                }
                context.Photos.RemoveRange(findphoto);
                var ImagePath=await imageManagementService.AddImageAsync(updateproductDTO.Photo, updateproductDTO.Name);
                var photos = ImagePath.Select(path => new Photo
                {
                    ImageName = path,
                    ProductId = updateproductDTO.Id,
                }).ToList();
               await context.Photos.AddRangeAsync(photos);
                await context.SaveChangesAsync();
                return true;
            }
        }
    }
}
