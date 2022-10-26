using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebApp.Models
{
    public class HomeIndexViewModel
    {
        public string[] xValues { get; set; }
        public int AnoRefefrencia { get; set; }
        public string SaldoCorretoraAtual { get; set; }
        public string SaldoTradesPeriodo { get; set; }
        public string SaldoMesAtual { get; set; }
        public string MaiorSaldoCorretora { get; set; }
        public string MenorSaldoCorretora { get; set; }
        public string MediaGanhosDia { get; set; }
        public string MediaPerdasDia { get; set; }
        public string RelacaoGanhoPerda { get; set; }
        public string QuantidadeGanhos { get; set; }
        public string QuantidadePerdas { get; set; }
        public string RelacaoQuantidadeGanhoPerda { get; set; }
        public List<KeyValuePair<string, decimal>> ResultadoMes { get; set; }

        public HomeIndexViewModel(int ano, DadosEstatisticos dados)
        {
            this.AnoRefefrencia = ano;
            this.SaldoCorretoraAtual = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.SaldoCorretoraAtual);
            this.SaldoTradesPeriodo = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.SaldoTradesPeriodo);
            this.MaiorSaldoCorretora = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MaiorSaldoCorretora);
            this.MenorSaldoCorretora = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MenorSaldoCorretora);
            this.MediaGanhosDia = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MediaGanhosDia);
            this.MediaPerdasDia = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MediaPerdasDia);
            this.RelacaoGanhoPerda = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.RelacaoGanhoPerda);
            this.QuantidadeGanhos = String.Format(new CultureInfo("pt-BR"), "{0:0}", dados.QuantidadeDiasGanhos);
            this.QuantidadePerdas = String.Format(new CultureInfo("pt-BR"), "{0:0}", dados.QuantidadeDiasPerdas);
            this.RelacaoQuantidadeGanhoPerda = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.RelacaoQuantidadeGanhoPerda);

            this.ResultadoMes = new List<KeyValuePair<string, decimal>>();
            foreach (var item in Enumerable.Range(1, 12).ToList())
            {
                var mes = "";
                switch (item)
                {
                    case 1:
                        mes = "Janeiro";
                        break;
                    case 2:
                        mes = "Fevereiro";
                        break;
                    case 3:
                        mes = "Março";
                        break;
                    case 4:
                        mes = "Abril";
                        break;
                    case 5:
                        mes = "Maio";
                        break;
                    case 6:
                        mes = "Junho";
                        break;
                    case 7:
                        mes = "Julho";
                        break;
                    case 8:
                        mes = "Agosto";
                        break;
                    case 9:
                        mes = "Setembro";
                        break;
                    case 10:
                        mes = "Outubro";
                        break;
                    case 11:
                        mes = "Novembro";
                        break;
                    case 12:
                        mes = "Dezembro";
                        break;
                };
                var valor = dados.ResultadoMes.Where(x => x.Key == item).Select(x => x.Value).SingleOrDefault();
                this.ResultadoMes.Add(new KeyValuePair<string, decimal>(mes, valor));
            };
        }
    }
}
