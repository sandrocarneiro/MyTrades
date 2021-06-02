using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NotaCorretagemInserirViewModel
    {
        public string Numero { get; set; }
        public string Data { get; set; }
        public string ContratosNegociados { get; set; }
        public string AjusteDayTrade { get; set; }

        public NotaCorretagem Instanciar()
        {
            return new NotaCorretagem(this.Numero,
                                      Convert.ToDateTime(this.Data),
                                      int.Parse(this.ContratosNegociados),
                                      Decimal.Parse(this.AjusteDayTrade));            
        }
    }
}
