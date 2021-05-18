using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models.NotaCorretagemViewModel
{
    public class NotaCorretagemInserirViewModel
    {
        public string Numero { get; set; }
        public string Data { get; set; }
        public string ContratosNegociados { get; set; }
        public string AjusteDayTrade { get; set; }

        public NotaCorretagem Instanciar()
        {
            return new NotaCorretagem()
            {
                Numero = this.Numero,
                Data = Convert.ToDateTime(this.Data),
                ContratosNegociados = int.Parse(this.ContratosNegociados),
                AjusteDayTrade = Decimal.Parse(this.AjusteDayTrade)
            };
        }
    }
}
