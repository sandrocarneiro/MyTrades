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

        public List<KeyValuePair<int, decimal>> ResultadoMes { get; set; }
        public List<KeyValuePair<DateTime, decimal>> TopLoss { get; set; }

        public DadosEstatisticos(int ano, List<Operacao> todasOperacoes)
        {
            var ops = new[] { "DAYTRADE", "EMOLUMENTOS", "REGISTRO", "IRRF" };
            List<ResultadoPorDia> resultadosPorDiaNoPeriodo = todasOperacoes
                                                            .Where(x => ops.Contains(x.TipoOperacao) && x.DataOperacao.Year == ano)
                                                            .GroupBy(x => x.DataOperacao)
                                                            .Select(x => new ResultadoPorDia
                                                            {
                                                                DataOperacao = x.First().DataOperacao,
                                                                Valor = x.Sum(y => y.Valor)
                                                            })
                                                            .ToList();

            this.SaldoCorretoraAtual = todasOperacoes.Sum(x => x.Valor);
            this.SaldoTradesPeriodo = resultadosPorDiaNoPeriodo.Sum(x => x.Valor);
            this.MediaGanhosDia = resultadosPorDiaNoPeriodo.Where(x => x.Valor > 0).Count() == 0 ? 0 : resultadosPorDiaNoPeriodo.Where(x => x.Valor > 0).Average(x => x.Valor);
            this.MediaPerdasDia = resultadosPorDiaNoPeriodo.Where(x => x.Valor < 0).Count() == 0 ? 0 : resultadosPorDiaNoPeriodo.Where(x => x.Valor < 0).Average(x => x.Valor);
            this.QuantidadeDiasGanhos = resultadosPorDiaNoPeriodo.Where(x => x.Valor > 0).Count();
            this.QuantidadeDiasPerdas = resultadosPorDiaNoPeriodo.Where(x => x.Valor < 0).Count();
            this.ResultadoMes = resultadosPorDiaNoPeriodo.GroupBy(x => x.DataOperacao.Month.ToString())
                                                               .Select(x => new KeyValuePair<int, decimal>(
                                                                                            x.First().DataOperacao.Month,
                                                                                            x.Sum(y => y.Valor))
                                                                        )
                                                               .ToList();
        }
    }
}
