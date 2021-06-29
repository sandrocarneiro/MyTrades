using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominio.Entidades
{
    public class DadosEstatisticos
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
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

        public DadosEstatisticos(int ano, int mes, decimal valor)
        {
            this.Ano = ano;
            this.Mes = mes;
        }

        public DadosEstatisticos(List<Historico> listaNotaCorretagem)
        {
            this.SaldoCorretoraAtual = listaNotaCorretagem.OrderByDescending(x => x.Data)
                                             .FirstOrDefault()
                                             .SaldoCorretora;

            this.SaldoTotalTrades = listaNotaCorretagem
                                          .Sum(x => x.Valor);

            this.MaiorSaldoCorretora = listaNotaCorretagem.OrderByDescending(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora;

            this.MenorSaldoCorretora = listaNotaCorretagem.OrderBy(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora;

            this.MediaGanhos = listaNotaCorretagem.Where(x => x.Valor > 0)
                                    .Average(x => x.Valor);

            this.MediaPerdas = listaNotaCorretagem.Where(x => x.Valor < 0)
                                    .Average(x => x.Valor);

            this.QuantidadeGanhos = listaNotaCorretagem.Where(x => x.Valor > 0)
                                         .Count();

            this.QuantidadePerdas = listaNotaCorretagem.Where(x => x.Valor < 0)
                                         .Count();

            this.RelacaoGanhoPerda = Math.Abs(MediaGanhos) > Math.Abs(MediaPerdas) ? 
                                        Math.Abs(MediaGanhos) / Math.Abs(MediaPerdas) : 
                                        -1 * Math.Abs(MediaPerdas) / Math.Abs(MediaGanhos);

            this.RelacaoQuantidadeGanhoPerda = Math.Abs(QuantidadeGanhos) > Math.Abs(QuantidadePerdas) ? 
                                                Math.Abs(QuantidadeGanhos) / Math.Abs(QuantidadePerdas) : 
                                                -1* Math.Abs(QuantidadePerdas) / Math.Abs(QuantidadeGanhos);

            this.TopGain = new List<KeyValuePair<DateTime, decimal>>();
            foreach (var item in listaNotaCorretagem.OrderByDescending(x => x.Valor).Take(3))
            {
                this.TopGain.Add(new KeyValuePair<DateTime, decimal>(item.Data, item.Valor));
            }


            this.TopLoss = new List<KeyValuePair<DateTime, decimal>>();
            foreach (var item in listaNotaCorretagem.OrderBy(x => x.Valor).Take(3))
            {
                this.TopLoss.Add(new KeyValuePair<DateTime, decimal>(item.Data, item.Valor));
            }

        }
    }
}
