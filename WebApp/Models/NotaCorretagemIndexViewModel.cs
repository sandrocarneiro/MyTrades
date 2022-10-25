using System;

namespace WebApp.Models
{
    public class NotaCorretagemIndexViewModel : NotaCorretagemViewModel
    {
        public int ID { get; set; }
        public string Cor { get; set; }
        public decimal TotalLiquidoNota { get; set; }
        public NotaCorretagemIndexViewModel(int id, DateTime data, string numero, int contratosNegociados, decimal totalLiquidoNota)
        {
            this.ID = id;
            this.Data = data;
            this.Numero = string.IsNullOrEmpty(numero) ? "" : numero;
            this.ContratosNegociados = contratosNegociados;
            this.TotalLiquidoNota = totalLiquidoNota;
        }


    }
}
