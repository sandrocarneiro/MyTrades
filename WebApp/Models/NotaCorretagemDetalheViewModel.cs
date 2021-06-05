using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NotaCorretagemDetalheViewModel : NotaCorretagemViewModel
    {
        public int ID { get; set; }
        public decimal TaxaRegistro { get; set; }
        public decimal TaxasBMF { get; set; }
        public decimal TaxaOperacional { get; set; }
        public decimal IRRF { get; set; }
        public decimal ISS { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal TotalLiquido { get; set; }
        public decimal TotalContaNormal { get; set; }
        public decimal TotalLiquidoNota { get; set; }


        public NotaCorretagemDetalheViewModel() { }

        public NotaCorretagemDetalheViewModel(NotaCorretagem nota)
        {
            this.ID = nota.ID;
            this.Data = nota.Data;
            this.Numero = nota.Numero;
            this.ContratosNegociados = nota.ContratosNegociados;
            this.AjusteDayTrade = nota.AjusteDayTrade;
            this.TaxaRegistro = nota.TaxaRegistro;
            this.TaxasBMF = nota.TaxasBMF;
            this.TaxaOperacional = nota.TaxaOperacional;
            this.IRRF = nota.IRRF;
            this.ISS = nota.ISS;
            this.TotalDespesas = nota.TotalDespesas;
            this.TotalLiquido = nota.TotalLiquido;
            this.TotalContaNormal = nota.TotalContaNormal;
            this.TotalLiquidoNota = nota.TotalLiquidoNota;
        }
    }
}
