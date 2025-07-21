using AutoMapper;
using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;
using ElectronicStore.Core.Interfaces;
using ElectronicStore.infrastructure.Data;
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

        public ProductRepositry(AppDbContext context, IMapper mapper) : base(context)
        {
            this.mapper = mapper;
        }

        public async Task<bool> AddAsync(AddProductDTO productDTO)
        {
            if (productDTO == null) return false;
            var product = mapper.Map<Product>(productDTO);
        }
    }
}
