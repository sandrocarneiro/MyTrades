using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class NotaCorretagem
    {
        public NotaCorretagem() { }
        public int ID { get; set; }
        public DateTime? Data { get; set; }
        public string Numero { get; set; }
        public int ContratosNegociados { get; set; }
        public decimal AjusteDayTrade { get; set; }

    }
}
