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
        public string Periodo 
        {
            get
            {
                return this.Data.Year.ToString("D4") + this.Data.Month.ToString("D2");
            }
        }
        public bool EhNotaCorretagem
        {
            get
            {
                return this.Tipo == "NC" ? true : false;
            }
        }

    }
}
