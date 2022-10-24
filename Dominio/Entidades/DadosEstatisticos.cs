using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominio.Entidades
{
    public class DadosEstatisticos
    {
        public decimal SaldoCorretoraAtual { get; set; }
        public decimal SaldoTradesPeriodo { get; set; }
        public decimal SaldoMesAtual { get; set; }
        public decimal MaiorSaldoCorretora { get; set; }
        public decimal MenorSaldoCorretora { get; set; }
        public decimal MediaGanhosDia { get; set; }
        public decimal MediaPerdasDia { get; set; }
        public decimal RelacaoGanhoPerda
        {
            get
            {
                return Math.Abs(this.MediaPerdasDia) == 0 ? 0 : Math.Abs(this.MediaGanhosDia) / Math.Abs(this.MediaPerdasDia);
            }
        }
        public decimal QuantidadeDiasGanhos { get; set; }
        public decimal QuantidadeDiasPerdas { get; set; }
        public decimal RelacaoQuantidadeGanhoPerda
        {
            get
            {
                return Math.Abs(QuantidadeDiasPerdas) == 0 ? 0 : Math.Abs(QuantidadeDiasGanhos) / Math.Abs(QuantidadeDiasPerdas);
            }
        }

        public List<KeyValuePair<DateTime, decimal>> TopGain { get; set; }
        public List<KeyValuePair<DateTime, decimal>> TopLoss { get; set; }

        public DadosEstatisticos(List<Historico> listaHistorico)
        {
            this.SaldoCorretoraAtual = 0; /*listaHistorico
                                            .OrderByDescending(x => x.Data)
                                            .FirstOrDefault()
                                            .SaldoCorretora;*/

            /*this.SaldoTotalTrades = 0; listaHistorico
                                            .Where(x => x.EhNotaCorretagem)
                                            .Sum(x => x.Valor);*/

            this.MaiorSaldoCorretora = 0; /*listaHistorico.OrderByDescending(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora;*/

            this.MenorSaldoCorretora = 0; /*listaHistorico.OrderBy(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora;*/

            this.MediaGanhosDia = 0; /*listaHistorico
                                            .Where(x => x.Valor > 0 && x.EhNotaCorretagem)
                                            .Average(x => x.Valor);*/

            this.MediaPerdasDia = 0; /*listaHistorico
                                            .Where(x => x.Valor < 0 && x.EhNotaCorretagem)
                                            .Average(x => x.Valor);*/

            this.QuantidadeDiasGanhos = 0; /*listaHistorico
                                            .Where(x => x.Valor > 0 && x.EhNotaCorretagem)
                                            .Count();*/

            this.QuantidadeDiasPerdas = 0; /*listaHistorico
                                            .Where(x => x.Valor < 0 && x.EhNotaCorretagem)
                                            .Count();*/

            /*this.RelacaoGanhoPerda = 0; Math.Abs(MediaGanhos) > Math.Abs(MediaPerdas) ? 
                                        Math.Abs(MediaGanhos) / Math.Abs(MediaPerdas) : 
                                        -1 * Math.Abs(MediaPerdas) / Math.Abs(MediaGanhos);*/

            /*this.RelacaoQuantidadeGanhoPerda = 0; Math.Abs(QuantidadeGanhos) > Math.Abs(QuantidadePerdas) ? 
                                                Math.Abs(QuantidadeGanhos) / Math.Abs(QuantidadePerdas) : 
                                                -1* Math.Abs(QuantidadePerdas) / Math.Abs(QuantidadeGanhos);*/

            this.TopGain = new List<KeyValuePair<DateTime, decimal>>();
            //foreach (var item in listaHistorico.Where(x => x.EhNotaCorretagem).OrderByDescending(x => x.Valor).Take(3))
            //{
            //    this.TopGain.Add(new KeyValuePair<DateTime, decimal>(item.Data, item.Valor));
            //}


            this.TopLoss = new List<KeyValuePair<DateTime, decimal>>();
            //foreach (var item in listaHistorico.Where(x => x.EhNotaCorretagem).OrderBy(x => x.Valor).Take(3))
            //{
            //    this.TopLoss.Add(new KeyValuePair<DateTime, decimal>(item.Data, item.Valor));
            //}

        }

        public DadosEstatisticos(List<Operacao> todasOperacoes)
        {
            var ops = new[] { "DAYTRADE", "EMOLUMENTOS", "REGISTRO", "IRRF" };

            List<ResultadoPorDia> resultadosPorDia = todasOperacoes
                                                            .Where(x => ops.Contains(x.TipoOperacao))
                                                            .GroupBy(x => x.DataOperacao)
                                                            .Select(x => new ResultadoPorDia
                                                            {
                                                                DataOperacao = x.First().DataOperacao,
                                                                Valor = x.Sum(y => y.Valor)
                                                            })
                                                            .ToList();

            this.SaldoCorretoraAtual = todasOperacoes.Sum(x => x.Valor);
            this.SaldoTradesPeriodo = resultadosPorDia.Where(x => x.DataOperacao.Year == DateTime.Now.Year).Sum(x => x.Valor);
            this.MediaGanhosDia = resultadosPorDia.Where(x => x.Valor > 0).Average(x => x.Valor);
            this.MediaPerdasDia = resultadosPorDia.Where(x => x.Valor < 0).Average(x => x.Valor);
            this.QuantidadeDiasGanhos = resultadosPorDia.Where(x => x.Valor > 0).Count();
            this.QuantidadeDiasPerdas = resultadosPorDia.Where(x => x.Valor < 0).Count();

        }
    }
}
