using AutoMapper;
using ElectronicStore.API.Helper;
using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;
using ElectronicStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.API.Controllers
{
  
    public class ProductsController : BaseController
    {
        public ProductsController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await work.ProductRepositry.GetAllAsync(x=>x.Category,x=>x.Photos);
                var result=mapper.Map<List<ProductDTO>>(products);
                if (products == null)
                    return BadRequest(new ResponseAPI(400));

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await work.ProductRepositry.GetByIdAsync(id, x => x.Category, x => x.Photos);
                var result = mapper.Map<ProductDTO>(product);
                if (product == null)
                {
                    return BadRequest(new ResponseAPI(400, $"Not found product id : {id}"));
                }
                return Ok(result);
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }

        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDTO productDTO)
        {
            try
            {
                var product = mapper.Map<Product>(productDTO);
                await work.ProductRepositry.AddAsync(product);

                return Ok(new ResponseAPI(200,"Product has been added"));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
