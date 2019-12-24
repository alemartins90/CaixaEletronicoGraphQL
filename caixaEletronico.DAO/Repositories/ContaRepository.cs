using caixa.Domain.Model;
using caixaEletronico.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixaEletronico.DAO.Repositories
{
    public class ContaRepository : RepositoryBase<Conta>, IContaRepository
    {
        private readonly CaixaEletronicoContext _context;

        public ContaRepository(CaixaEletronicoContext context) : base(context)
        {
            _context = context;
        }

        public Conta GetByConta(int numeroConta)
        {
            return _context.Conta.Where(k => k.conta == numeroConta).FirstOrDefault();
        }

        public Conta RealizarSaque(decimal valor, int numeroConta)
        {
            Conta conta = GetByConta(numeroConta);

            conta.saldo = conta.saldo - valor;

            _context.Update(conta);
            _context.SaveChanges();

            return conta;
        }

        public Conta RealizarDeposito(decimal valor, int numeroConta)
        {
            Conta conta = GetByConta(numeroConta);

            conta.saldo = conta.saldo - valor;

            _context.Update(conta);
            _context.SaveChanges();

            return conta;
        }
        public Decimal GetSaldo(int numeroConta)
        {
            Conta conta = GetByConta(numeroConta);

            return conta.saldo;
        }

        public Conta SetSaldo(decimal valor, int numeroConta)
        {
            Conta conta = GetByConta(numeroConta);

            conta.saldo = valor;

            _context.Update(conta);
            _context.SaveChanges();

            return conta;
        }
    }
}
