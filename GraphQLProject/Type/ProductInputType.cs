using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLProject.Type
{
    public class ProductInputType :InputObjectGraphType
    {
        public ProductInputType()
        {
            Field<IntGraphType>("Id");
            Field<StringGraphType>("name");
            Field<FloatGraphType>("price");
        }
    }
}
