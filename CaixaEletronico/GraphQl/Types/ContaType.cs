
using caixa.Domain.Model;
using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaixaEletronico.Types
{
    public class ContaType : ObjectGraphType<Conta>
    {
        public ContaType()
        {
            Name = "Conta";
            Field(k => k.idConta, type:typeof(IdGraphType)).Description("Id conta");
            Field(k => k.conta).Description("Número da conta");
            Field(k => k.saldo).Description("Saldo na conta");
        }
    }
}
