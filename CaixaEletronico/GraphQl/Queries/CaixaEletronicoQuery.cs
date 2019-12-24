using caixaEletronico.DAO.Repositories;
using CaixaEletronico.Helper;
using CaixaEletronico.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Queries
{
    public class CaixaEletronicoQuery : ObjectGraphType<object>
    {
        public CaixaEletronicoQuery(ContextServiceLocator contextServiceLocator)
        {
            Field<DecimalGraphType>("saldo",
                arguments: new QueryArguments(new QueryArgument[]
                {
                    new QueryArgument<IntGraphType>{Name="conta"}
                }),
                resolve: context =>
                {
                    var numeroConta = context.GetArgument<int>("conta");
                    var conta = contextServiceLocator.ContaRepository.GetByConta(numeroConta);
                    if (conta == null)
                    {
                        context.Errors.Add(new GraphQL.ExecutionError("Conta não cadastrada"));
                        return null;
                    }

                    return conta.saldo;
                }

                );
        }
    }
}
