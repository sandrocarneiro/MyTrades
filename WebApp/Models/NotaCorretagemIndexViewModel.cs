using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NotaCorretagemIndexViewModel : NotaCorretagemViewModel
    {
        public int ID { get; set; }
        //public new string Data { get; set; }
        //public new string ContratosNegociados { get; set; }
        public decimal TotalLiquidoNota { get; set; }
        public NotaCorretagemIndexViewModel(int id, DateTime data, int contratosNegociados, decimal totalLiquidoNota)
        {
            this.ID = id;
            this.Data = data;
            this.ContratosNegociados = contratosNegociados;
            this.TotalLiquidoNota = totalLiquidoNota;



            //this.ID = id.ToString();
            //this.Data = data.ToString("dd/MM/yyyy");
            //this.ContratosNegociados = String.Format(new CultureInfo("pt-BR"), "{0:0}", contratosNegociados);
            //this.TotalLiquidoNota = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", totalLiquidoNota);
        }
    }
}
