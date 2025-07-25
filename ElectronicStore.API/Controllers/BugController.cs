using AutoMapper;
using ElectronicStore.API.Helper;
using ElectronicStore.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicStore.API.Controllers
{
  
    public class BugController : BaseController
    {
        public BugController(IUnitOfWork work, IMapper mapper) : base(work, mapper)
        {
        }
        [HttpGet("not-found")]
        public IActionResult GetNotFound()
        {
            var category = work.CategoryRepositry.GetByIdAsync(1000);
            if(category == null)
                return NotFound();
            return Ok(category);
        }
        [HttpGet("server-error")]
        public IActionResult ServerError()
        {
            var category = work.CategoryRepositry.GetByIdAsync(1000);
            if (category == null)
                return NotFound();
            return Ok(category);
        }
    }
}
