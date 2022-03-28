using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GraphQLProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private IProduct _productService;

      public ProductController(IProduct product)
      {
            _productService = product;
      }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _productService.GetAllProducts();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _productService.GetProductById(id); 
        }

        // POST api/<ProductController>
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            _productService.AddProduct(product);
            return product;
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public Product Put(int id, [FromBody] Product product)
        {
            _productService.UpdateProduct(id, product);
            return product;
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.DeleteProduct(id);
        }
    }
}
