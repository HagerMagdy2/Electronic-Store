using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicStore.Core.Interfaces
{
    public interface IProductRepositry:IGenericRepositry<Product>
    {
        Task<bool> AddAsync (AddProductDTO productDTO);
        Task<bool> UpdateAsync (UpdateProductDTO updateproductDTO);
        Task DeleteAsync (Product product);
    }
}
