using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NotaCorretagemEditarViewModel
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Numero { get; set; }
        public string ContratosNegociados { get; set; }

        public string AjusteDayTrade { get; set; }
        public string TaxaRegistro { get; set; }
        public string TaxasBMF { get; set; }
        public string TaxaOperacional { get; set; }
        public string IRRF { get; set; }
        public string ISS { get; set; }
        public string TotalDespesas { get; set; }
        public string TotalLiquido { get; set; }
        public string TotalContaNormal { get; set; }
        public string TotalLiquidoNota { get; set; }
        public NotaCorretagemEditarViewModel() { }

        public NotaCorretagemEditarViewModel(NotaCorretagem nota)
        {
            this.ID = nota.ID;
            this.Data = nota.Data;
            this.Numero = nota.Numero;
            this.ContratosNegociados = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.ContratosNegociados);
            this.AjusteDayTrade = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.AjusteDayTrade);
            this.TaxaRegistro = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TaxaRegistro);
            this.TaxasBMF = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TaxasBMF);
            this.TaxaOperacional = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TaxaOperacional);
            this.IRRF = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.IRRF);
            this.ISS = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.ISS);
            this.TotalDespesas = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TotalDespesas);
            this.TotalLiquido = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TotalLiquido);
            this.TotalContaNormal = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TotalContaNormal);
            this.TotalLiquidoNota = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", nota.TotalLiquidoNota);
        }
    }
}
