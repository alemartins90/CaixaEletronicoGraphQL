using caixaEletronico.DAO;
using caixaEletronico.DAO.Repositories;
using CaixaEletronico.Helper;
using CaixaEletronico.InputTypes;

using CaixaEletronico.Types;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.GraphQl.Queries
{
    public class CaixaEletronicoMutation : ObjectGraphType
    {
        
        public CaixaEletronicoMutation(ContextServiceLocator contextServiceLocator)
        {
            Name = "Mutation";

            Field<ContaType>(
            "sacar",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                                            new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "valor" }),
            resolve: context =>
            {
                var numeroConta = context.GetArgument<int>("conta");
                var valor = context.GetArgument<decimal>("valor");

                var conta = contextServiceLocator.ContaRepository.GetByConta(numeroConta);

                if (conta == null)
                {
                    context.Errors.Add(new GraphQL.ExecutionError("Conta não cadastrada"));
                    return null;
                }

                if (conta.saldo > valor)
                    conta = contextServiceLocator.ContaRepository.SetSaldo(conta.saldo - valor, numeroConta);
                else
                {
                    context.Errors.Add(new GraphQL.ExecutionError("Saldo insuficiente"));
                    return null;
                }
                
                return conta;
            }
            );

            Field<ContaType>(
            "depositar",
            arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "conta" },
                                            new QueryArgument<NonNullGraphType<DecimalGraphType>> { Name = "valor" }),
            resolve: context =>
            {
                var numeroConta = context.GetArgument<int>("conta");
                var valor = context.GetArgument<decimal>("valor");
                //ContaRepository contaRepository = new ContaRepository(caixaEletronicoContext);

                var conta = contextServiceLocator.ContaRepository.GetByConta(numeroConta);
                if (conta == null)
                {
                    context.Errors.Add(new GraphQL.ExecutionError("Conta não cadastrada"));
                    return null;
                }

                conta = contextServiceLocator.ContaRepository.SetSaldo(conta.saldo + valor, numeroConta);

                return conta;
            }
            );
        }
    }
}
