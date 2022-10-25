using Dominio.Entidades;
using Dominio.Servicos;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;

namespace ServicoAplicacao
{
    public class MovimentacaoContaCorrenteServico
    {
        private MovimentacaoContaCorrenteRepositorio ColecaoMovimentacaoContaCorrente;
        private HistoricoServicoDominio HistoricoServicoDominio;
        private NotaCorretagemRepositorio ColecaoNotaCorretagem;
        private HistoricoRepositorio ColecaoHistorico;


        public MovimentacaoContaCorrenteServico()
        {
            this.ColecaoMovimentacaoContaCorrente = new MovimentacaoContaCorrenteRepositorio();
            this.HistoricoServicoDominio = new HistoricoServicoDominio();
            this.ColecaoNotaCorretagem = new NotaCorretagemRepositorio();
            this.ColecaoHistorico = new HistoricoRepositorio();
        }

        public void Inserir(MovimentacaoContaCorrente movimentacaoCC)
        {
            this.ColecaoMovimentacaoContaCorrente.Inserir(movimentacaoCC);
            List<NotaCorretagem> listaNotas = this.ColecaoNotaCorretagem.ObterHistorico(new DateTime(2021, 1, 1));
            List<MovimentacaoContaCorrente> listaMovimentacaoCC = ColecaoMovimentacaoContaCorrente.ObterHistorico(new DateTime(2021, 1, 1));
            List<Historico> historico = this.HistoricoServicoDominio.Reconstruir(listaNotas, listaMovimentacaoCC);
            ColecaoHistorico.Atualizar(historico);
        }
    }
}
