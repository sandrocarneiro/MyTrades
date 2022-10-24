using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HomeIndexViewModel
    {
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
        public List<KeyValuePair<string, string>> TopGain { get; set; }
        public List<KeyValuePair<string, string>> TopLoss { get; set; }

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

            this.TopGain = new List<KeyValuePair<string, string>>();
            //foreach (var item in dados.TopGain)
            //{
            //    this.TopGain.Add(new KeyValuePair<string, string>(item.Key.ToString("dd/MM/yy"), String.Format(new CultureInfo("pt-BR"), "{0:0.00}", item.Value)));
            //}


            this.TopLoss = new List<KeyValuePair<string, string>>();
            //foreach (var item in dados.TopLoss)
            //{
            //    this.TopLoss.Add(new KeyValuePair<string, string>(item.Key.ToString("dd/MM/yy"), String.Format(new CultureInfo("pt-BR"), "{0:0.00}", item.Value)));
            //}
        }
    }
}
