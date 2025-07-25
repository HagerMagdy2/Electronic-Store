﻿using AutoMapper;
using ElectronicStore.API.Helper;
using ElectronicStore.Core.DTOs;
using ElectronicStore.Core.Entities.Product;
using ElectronicStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.API.Controllers
{

    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork work, IMapper mapper) : base(work,mapper)
        {
        }
        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var category = await work.CategoryRepositry.GetAllAsync();
                if (category == null)
                    return BadRequest(new ResponseAPI(400));

                return Ok(category);
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
                var category = await work.CategoryRepositry.GetByIdAsync(id);
                if (category == null)
                    return BadRequest(new ResponseAPI(400 , $"Not found category id : {id}"));

                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("add-category")]
        public async Task<IActionResult> Add(CategoryDTO categoryDTO)
        {
            try
            {
                var category = mapper.Map<Category>(categoryDTO);
                await work.CategoryRepositry.AddAsync(category);
                return Ok(new ResponseAPI(200, "Item Has been Added"));

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        //My Way
        //[HttpPut("update-category")]
        //public async Task<IActionResult> Update(int Id,CategoryDTO categoryDTO)
        //{
        //    try
        //    {
        //        var category = await work.CategoryRepositry.GetByIdAsync(Id);
        //        if (category == null)
        //            return NotFound();
        //        category.Name = categoryDTO.Name;
        //        category.Description = categoryDTO.Description;
        //        await work.CategoryRepositry.UpdateAsync(category);
        //        return Ok(new {message= "Item Has been Updated"});
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
        //}
        //another way for Update // The Video Way // using Update DTO
        [HttpPut("update-category")]
        public async Task<IActionResult> Update(UpdateCategoryDTO UpdatecategoryDTO)
        {
            try
            {
                var category = mapper.Map<Category>(UpdatecategoryDTO);
                await work.CategoryRepositry.UpdateAsync(category);
                return Ok(new ResponseAPI(200,"Item Has been Updates"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("delete-category/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await work.CategoryRepositry.DeleteAsync(id);
                return Ok(new ResponseAPI(200, "Item has been Deleted"));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        } 
        }
}
