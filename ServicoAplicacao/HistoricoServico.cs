using Dominio.Entidades;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ServicoAplicacao
{
    public class HistoricoServico
    {
        private HistoricoRepositorio ColecaoHistorico;
        private OperacaoRepositorio ColeacoOperacao;
        public HistoricoServico()
        {
            this.ColecaoHistorico = new HistoricoRepositorio();
            this.ColeacoOperacao = new OperacaoRepositorio();
        }
        public List<Historico> ObterNotaCorretagem(string periodo)
        {
            return this.ColecaoHistorico.ObterNotaCorretagem(periodo);
        }

        public List<Historico> ObterNotaCorretagem()
        {
            return this.ColecaoHistorico.ObterNotaCorretagem();
        }

        public DadosEstatisticos ObterDadosEstatisticos()
        {
            return new DadosEstatisticos(this.ColeacoOperacao.Obter());            
        }
        public List<HistoricoMensal> ObterDadosEstatisticosPorMes()
        {
            List<Historico> lista = this.ColecaoHistorico.ObterNotaCorretagem().OrderByDescending(x => x.Data).ToList();
            List<HistoricoMensal> historicoMensal = new List<HistoricoMensal>();

            foreach (var item in lista.GroupBy(x => new { x.Data.Year, x.Data.Month }).ToList())
            {
                int qtdeGanhos = lista.Where(x => x.Data.Year == item.Key.Year &&
                                                       x.Data.Month == item.Key.Month &&
                                                       x.Valor > 0)
                                            .Count();

                int qtdePerdas = lista.Where(x => x.Data.Year == item.Key.Year &&
                                                       x.Data.Month == item.Key.Month &&
                                                       x.Valor < 0)
                                            .Count();


                decimal mediaGanhos = lista.Where(x => x.Data.Year == item.Key.Year &&
                                                       x.Data.Month == item.Key.Month &&
                                                       x.Valor > 0)
                                            .Average(x => x.Valor);

                decimal mediaPerdas = lista.Where(x => x.Data.Year == item.Key.Year &&
                                                       x.Data.Month == item.Key.Month &&
                                                       x.Valor < 0)
                                            .Average(x => x.Valor);

                decimal total = lista.Where(x => x.Data.Year == item.Key.Year &&
                                                       x.Data.Month == item.Key.Month)
                                            .Sum(x => x.Valor);

                historicoMensal.Add(new HistoricoMensal(item.Key.Year, item.Key.Month, total, qtdeGanhos, qtdePerdas, mediaGanhos, mediaPerdas));
            };

            return historicoMensal;
        }
    }
}
