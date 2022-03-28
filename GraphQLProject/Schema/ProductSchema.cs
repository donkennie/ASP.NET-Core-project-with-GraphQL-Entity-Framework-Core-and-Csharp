using GraphQLProject.Mutation;
using GraphQLProject.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Schema
{
    public class ProductSchema: GraphQL.Types.Schema
    {
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation) 
        {
            Query = productQuery;
            Mutation = productMutation;
        }
    }
}
