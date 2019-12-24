using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.InputTypes
{
    public class ContaInputType : InputObjectGraphType
    {
        public ContaInputType()
        {
            Name = "contaInput";
            Field<NonNullGraphType<IntGraphType>>("numeroConta");
            Field<DecimalGraphType>("valor");
        }
    }
}
