using caixa.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace caixaEletronico.Domain.Interfaces
{
    public interface IContaRepository : IRepositoryBase<Conta>
    {
        Conta GetByConta(int numeroConta);

        Conta SetSaldo(decimal valor, int numeroConta);

        Decimal GetSaldo(int numeroConta);

        Conta RealizarSaque(decimal valor, int numeroConta);

        Conta RealizarDeposito(decimal valor, int numeroConta);
    }
}
