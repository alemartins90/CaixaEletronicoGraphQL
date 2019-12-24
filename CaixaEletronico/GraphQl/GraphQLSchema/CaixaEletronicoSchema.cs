

using CaixaEletronico.GraphQl.Queries;
using CaixaEletronico.Queries;
using GraphQL.Types;
using GraphQL.Utilities;
using System;

namespace CaixaEletronico.GraphQl.GraphQLSchema
{
    public class CaixaEletronicoSchema : Schema
    {
        public CaixaEletronicoSchema(IServiceProvider provider)
            : base(provider)
        {
            Query = provider.GetRequiredService<CaixaEletronicoQuery>();
            Mutation = provider.GetRequiredService<CaixaEletronicoMutation>();
        }
}
}
