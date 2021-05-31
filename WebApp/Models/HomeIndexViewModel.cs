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
        public string SaldoCorretoraAtual { get; set; }
        public string SaldoTotalTrades { get; set; }
        public string SaldoMesAtual { get; set; }
        public string MaiorSaldoCorretora { get; set; }
        public string MenorSaldoCorretora { get; set; }
        public string MediaGanhos { get; set; }
        public string MediaPerdas { get; set; }
        public string RelacaoGanhoPerda { get; set; }
        public string QuantidadeGanhos { get; set; }
        public string QuantidadePerdas { get; set; }
        public string RelacaoQuantidadeGanhoPerda { get; set; }
        public List<KeyValuePair<string, string>> TopGain { get; set; }
        public List<KeyValuePair<string, string>> TopLoss { get; set; }

        public HomeIndexViewModel(DadosEstatisticos dados)
        {
            this.SaldoCorretoraAtual = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.SaldoCorretoraAtual);
            this.SaldoTotalTrades = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.SaldoTotalTrades);
            this.MaiorSaldoCorretora = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MaiorSaldoCorretora);
            this.MenorSaldoCorretora = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MenorSaldoCorretora);
            this.MediaGanhos = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MediaGanhos);
            this.MediaPerdas = "R$ " + String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.MediaPerdas);
            this.RelacaoGanhoPerda = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.RelacaoGanhoPerda);
            this.QuantidadeGanhos = String.Format(new CultureInfo("pt-BR"), "{0:0}", dados.QuantidadeGanhos);
            this.QuantidadePerdas = String.Format(new CultureInfo("pt-BR"), "{0:0}", dados.QuantidadePerdas);
            this.RelacaoQuantidadeGanhoPerda = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", dados.RelacaoQuantidadeGanhoPerda);

            this.TopGain = new List<KeyValuePair<string, string>>();
            foreach (var item in dados.TopGain)
            {
                this.TopGain.Add(new KeyValuePair<string, string>(item.Key.ToString("dd/mm/yy"), String.Format(new CultureInfo("pt-BR"), "{0:0.00}", item.Value)));
            }


            this.TopLoss = new List<KeyValuePair<string, string>>();
            foreach (var item in dados.TopLoss)
            {
                this.TopLoss.Add(new KeyValuePair<string, string>(item.Key.ToString("dd/mm/yy"), String.Format(new CultureInfo("pt-BR"), "{0:0.00}", item.Value)));
            }
        }
    }
}
