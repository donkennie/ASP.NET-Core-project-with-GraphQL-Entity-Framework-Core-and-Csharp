using GraphQL;
using GraphQL.Types;
using GraphQLProject.Interfaces;
using GraphQLProject.Models;
using GraphQLProject.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Mutation
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("CreateProduct", arguments: new QueryArguments(new QueryArgument<ProductInputType> { Name = "product" }),

               resolve: context =>
               {
                   return productService.AddProduct(context.GetArgument<Product>("product"));
               });


            Field<ProductType>("UpdateProduct", 
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" },
                 new QueryArgument<ProductInputType> { Name = "product" }),

              resolve: context =>
              {
                  var ProductObj = context.GetArgument<Product>("product");
                  var ProductId = context.GetArgument<int>("id");

                  return productService.UpdateProduct(ProductId, ProductObj);

                  //return productService.UpdateProduct(context.GetArgument<int>("id"), context.GetArgument<Product>("product"));
              });


            Field<StringGraphType>("DeleteProduct",
               arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
              

             resolve: context =>
             {
                 var ProductId = context.GetArgument<int>("id");

                  productService.DeleteProduct(ProductId);
                 return "The product against the" + ProductId + "has been deleted";
              });
        }
    }
}
