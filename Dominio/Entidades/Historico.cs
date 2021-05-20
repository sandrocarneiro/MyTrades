using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Historico
    {
        public DateTime Data { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public decimal SaldoCorretora { get; set; }

    }
}
