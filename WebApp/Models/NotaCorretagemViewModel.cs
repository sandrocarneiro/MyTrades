using Dominio.Entidades;
using System;

namespace WebApp.Models
{
    public class NotaCorretagemViewModel
    {
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int ContratosNegociados { get; set; }
        public decimal? AjusteDayTrade { get; set; }

        public NotaCorretagemViewModel() { }

        public NotaCorretagem Instanciar()
        {

            return new NotaCorretagem(string.IsNullOrEmpty(this.Numero) ? "" : this.Numero.Trim(),
                                      this.Data,
                                      this.ContratosNegociados,
                                      this.AjusteDayTrade.Value);
        }
    }
}
