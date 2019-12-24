using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace caixa.Domain.Model
{
    public class Conta
    {
        [Key]
        [Column("IdConta")]
        public int idConta { get; set; }

        [Column("NumeroConta")]
        public int conta { get; set; }

        [Column("Saldo")]
        public decimal saldo { get; set; }
    }
}
