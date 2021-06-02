using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NotaCorretagemViewModel
    {
        public string ID { get; set; }
        public string Data { get; set; }
        public string ContratosNegociados { get; set; }
        public string TotalLiquidoNota { get; set; }
        public NotaCorretagemViewModel(int id, DateTime data, int contratosNegociados, decimal totalLiquidoNota)
        {
            this.ID = id.ToString();
            this.Data = data.ToString("dd/MM/yyyy");
            this.ContratosNegociados = String.Format(new CultureInfo("pt-BR"), "{0:0}", contratosNegociados);
            this.TotalLiquidoNota = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", totalLiquidoNota);
        }
    }
}
