using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominio.Entidades
{
    public class DadosEstatisticos
    {
        public decimal SaldoCorretoraAtual { get; set; }
        public decimal SaldoTotalTrades { get; set; }
        public decimal SaldoMesAtual { get; set; }
        public decimal MaiorSaldoCorretora { get; set; }
        public decimal MenorSaldoCorretora { get; set; }
        public decimal MediaGanhos { get; set; }
        public decimal MediaPerdas { get; set; }
        public decimal RelacaoGanhoPerda { get; set; }
        public decimal QuantidadeGanhos { get; set; }
        public decimal QuantidadePerdas { get; set; }
        public decimal RelacaoQuantidadeGanhoPerda { get; set; }

        public List<KeyValuePair<DateTime, decimal>> TopGain { get; set; }
        public List<KeyValuePair<DateTime, decimal>> TopLoss { get; set; }


        public DadosEstatisticos(List<Historico> lista)
        {
            this.SaldoCorretoraAtual = lista.OrderByDescending(x => x.Data)
                                             .FirstOrDefault()
                                             .SaldoCorretora;

            this.SaldoTotalTrades = lista.Where(x => x.Tipo == "NC")
                                          .Sum(x => x.Valor);

            this.MaiorSaldoCorretora = lista.OrderByDescending(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora;

            this.MenorSaldoCorretora = lista.OrderBy(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora;

            this.MediaGanhos = lista.Where(x => x.Tipo == "NC" && x.Valor > 0)
                                    .Average(x => x.Valor);

            this.MediaPerdas = lista.Where(x => x.Tipo == "NC" && x.Valor < 0)
                                    .Average(x => x.Valor);

            this.QuantidadeGanhos = lista.Where(x => x.Tipo == "NC" && x.Valor > 0)
                                         .Count();

            this.QuantidadePerdas = lista.Where(x => x.Tipo == "NC" &&  x.Tipo == "NC" &&x.Valor < 0)
                                         .Count();

            this.RelacaoGanhoPerda = Math.Abs(MediaGanhos > MediaPerdas ? MediaGanhos / MediaPerdas : -1 * MediaPerdas / MediaGanhos);

            this.RelacaoQuantidadeGanhoPerda = Math.Abs(QuantidadeGanhos > QuantidadePerdas ? QuantidadeGanhos / QuantidadePerdas : -1* QuantidadePerdas / QuantidadeGanhos );

            this.TopGain = new List<KeyValuePair<DateTime, decimal>>();
            foreach (var item in lista.Where(x => x.Tipo == "NC").OrderByDescending(x => x.Valor).Take(3))
            {
                this.TopGain.Add(new KeyValuePair<DateTime, decimal>(item.Data, item.Valor));
            }


            this.TopLoss = new List<KeyValuePair<DateTime, decimal>>();
            foreach (var item in lista.Where(x => x.Tipo == "NC").OrderBy(x => x.Valor).Take(3))
            {
                this.TopLoss.Add(new KeyValuePair<DateTime, decimal>(item.Data, item.Valor));
            }

        }
    }
}
