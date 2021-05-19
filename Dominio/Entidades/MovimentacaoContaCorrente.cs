using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class MovimentacaoContaCorrente
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public decimal SaldoCorretora { get; set; }
    }
}
