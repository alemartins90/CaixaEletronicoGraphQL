using caixa.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace caixaEletronico.DAO
{
    public class CaixaEletronicoContext : DbContext
    {
        public CaixaEletronicoContext(DbContextOptions<CaixaEletronicoContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>().ToTable("TB_CONTA");
        }

        public DbSet<Conta> Conta { get; set; }
    }
}
