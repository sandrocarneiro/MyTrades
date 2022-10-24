using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class ResultadoPorDia
    {
        public DateTime DataOperacao { get; set; }
        public string TipoOperacao { get; set; }
        public decimal Valor { get; set; }
        
    }
}
