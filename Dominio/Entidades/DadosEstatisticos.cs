using System;
using System.Collections.Generic;
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

        public List<KeyValuePair<string, decimal>> ResultadoMes { get; set; }
        public List<KeyValuePair<DateTime, decimal>> TopLoss { get; set; }

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
            this.ResultadoMes = resultadosPorDia.GroupBy(x => x.DataOperacao.Month.ToString())
                                                               .Select(x => new KeyValuePair<string, decimal>(
                                                                                            x.First().DataOperacao.Month.ToString("00"),
                                                                                            x.Sum(y => y.Valor))
                                                                        )
                                                               .ToList();


        }
    }
}
