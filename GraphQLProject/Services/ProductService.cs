using GraphQLProject.Data;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Services
{
    public class ProductService : IProduct
    {
        private GraphQLDbContext _dbContext;

        public ProductService(GraphQLDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productObj = _dbContext.Products.Find(id);
            _dbContext.Products.Remove(productObj);
            _dbContext.SaveChanges();

            /* var p =  products.Find(p => p.Id == id);
              if (p == null)
                  return BadRequest("p is not Found");
              products.Remove(p);
              return Ok(products);*/

        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);


            /*
              var p= products.Find(p => p.Id == id);
             if(p == null)
            return BadRequest("p is not Found")
            return Ok(p)
            */
        }

        public Product UpdateProduct(int id, Product product)
        {

            var productObj = _dbContext.Products.Find(id);
            productObj.Name = product.Name;
            productObj.Price = product.Price;
            _dbContext.SaveChanges();
            return product;

            /* var p = products.Find(a => a.Id == product.Id);
             if (p == null)
                 return BadRequest("p is not Found");
             p.Id = product.Id;
             p.Name = product.Name;
             p.Price = product.Price;

             return Ok(products);*/




        }
    }
}
