using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class NotaCorretagem
    {
        public NotaCorretagem() { }
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string DataFormatoUniversal
        {
            get
            {
                return this.Data.Year.ToString() + this.Data.Month.ToString().PadLeft(2, '0') + this.Data.Day.ToString().PadLeft(2, '0');
            }
        }
        public string Numero { get; set; }
        public int ContratosNegociados { get; set; }
        public decimal AjusteDayTrade { get; set; }
        public decimal TaxaRegistro { get; set; }
        public decimal TaxasBMF { get; set; }
        public decimal TaxaOperacional { get; set; }
        public decimal IRRF { get; set; }
        public decimal ISS { get; set; }
        public decimal TotalDespesas
        {
            get
            {
                return this.TaxaOperacional + this.TaxaRegistro + this.TaxasBMF;
            }
        }
        public decimal TotalLiquido
        {
            get
            {
                return this.TaxaOperacional + this.TaxaRegistro + this.TaxasBMF + this.AjusteDayTrade;
            }
        }
        public decimal TotalContaNormal
        {
            get
            {
                return this.TaxaOperacional + this.TaxaRegistro + this.TaxasBMF + this.AjusteDayTrade + this.IRRF;
            }
        }
        public decimal TotalLiquidoNota
        {
            get
            {
                return this.TotalContaNormal + this.ISS;
            }
        }

        public NotaCorretagem(int id, DateTime data, string numero, int contratosNegociados, decimal ajusteDayTrade,
                                decimal taxaRegistro, decimal taxasBMF, decimal taxaOperacional, decimal irrf, decimal iss)
        {
            this.ID = id;
            this.Data = data;
            this.Numero = numero;
            this.ContratosNegociados = contratosNegociados;
            this.AjusteDayTrade = ajusteDayTrade;
            this.TaxaRegistro = taxaRegistro;
            this.TaxasBMF = taxasBMF;
            this.TaxaOperacional = TaxaOperacional;
            this.IRRF = irrf;
            this.ISS = iss;
        }

        public NotaCorretagem(int id,
                              string numero,
                              DateTime data,
                              int contratosNegociados,
                              decimal ajusteDayTrade)
            : this(numero, data, contratosNegociados, ajusteDayTrade)
        {
            this.ID = id;
        }


        public NotaCorretagem(string numero,
                              DateTime data,
                              int contratosNegociados,
                              decimal ajusteDayTrade)
        {
            this.Numero = numero;
            this.Data = data;
            this.ContratosNegociados = contratosNegociados;
            this.AjusteDayTrade = ajusteDayTrade;

            this.TaxaOperacional = 0.00m;
            this.TaxaRegistro = -0.45m * this.ContratosNegociados * 0.1556m * 2.42m;
            this.TaxasBMF = Math.Ceiling((-0.45m * this.ContratosNegociados * 0.133m * 1.35m) * 100) / 100;
            this.IRRF = this.TotalLiquido > 0 ? -1 * this.TotalLiquido / 100 : 0;
            this.ISS = 0.09m * this.TaxaOperacional;
        }
    }
}