using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HistoricoViewModel
    {
        public string Data { get; set; }
        public string Tipo { get; set; }
        public bool Negativo{ get; set; }
        public string Valor { get; set; }
        public string SaldoCorretora { get; set; }
        public HistoricoViewModel(DateTime data, string tipo, decimal valor, decimal saldoCorretora)
        {
            this.Data = data.ToString("dd/MM/yyyy");
            this.Tipo = tipo;
            this.Valor = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", valor);
            this.Negativo = valor < 0 ? true : false;
            this.SaldoCorretora = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", saldoCorretora);
        }
    }
}
