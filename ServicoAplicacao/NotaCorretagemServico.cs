using Dominio.Entidades;
using Dominio.Servicos;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoAplicacao
{
    public class NotaCorretagemServico
    {
        private NotaCorretagemRepositorio ColecaoNotaCorretagem;
        private HistoricoRepositorio ColecaoHistorico;
        private HistoricoServicoDominio HistoricoServicoDominio;
        private MovimentacaoContaCorrenteRepositorio ColecaoMovimentacaoContaCorrente;

        public NotaCorretagemServico()
        {
            this.ColecaoNotaCorretagem = new NotaCorretagemRepositorio();
            this.HistoricoServicoDominio = new HistoricoServicoDominio();
            this.ColecaoHistorico = new HistoricoRepositorio();
            this.ColecaoMovimentacaoContaCorrente = new MovimentacaoContaCorrenteRepositorio();
        }

        public List<NotaCorretagem> ObterTodas()
        {
            return this.ColecaoNotaCorretagem.ObterHistorico();
        }

        public void Inserir(NotaCorretagem notaCorretagem)
        {            
            this.ColecaoNotaCorretagem.Inserir(notaCorretagem);
            List <NotaCorretagem> listaNotas = this.ColecaoNotaCorretagem.ObterHistorico(new DateTime(2021,1,1));
            List<MovimentacaoContaCorrente> listaMovimentacaoCC = ColecaoMovimentacaoContaCorrente.ObterHistorico(new DateTime(2021, 1, 1));
            List<Historico> historico = this.HistoricoServicoDominio.Reconstruir(listaNotas, listaMovimentacaoCC);
            ColecaoHistorico.Atualizar(historico);
        }
    }
}
