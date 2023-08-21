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
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;
        public ProductController()
        {
            _productRepository = new ProductRepository();
        } 
    
        [HttpPost]
        public async Task<ActionResult> Create(Product product)
        {
            await _productRepository.Add(product);
            return Ok();
            // try
            // {
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            //     //throw;

            //     return BadRequest();
            // }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            return Ok(await _productRepository.GetAll());
            // try
            // {
            // }
            // catch (Exception e)
            // {
            //     Console.WriteLine(e.Message);
            //     //throw;
            //     return BadRequest();
            // }
        }
    }
}