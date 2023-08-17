using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopRevendb.Model;
using ShopRevendb.Repository;

namespace ShopRevendb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
         private readonly CategoryRepository _categoryRepository;
        public CategoryController()
        {
            _categoryRepository = new CategoryRepository();
        } 
        [HttpPost]
        public async Task<ActionResult> Create(Category product)
        {
            await _categoryRepository.Add(product);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            return Ok(await _categoryRepository.GetAll());
        }
    }
}