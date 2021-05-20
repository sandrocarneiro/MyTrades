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

        public void Inserir(NotaCorretagem notaCorretagem)
        {            
            this.ColecaoNotaCorretagem.Inserir(notaCorretagem);
            NotaCorretagem notaAnterior = this.ColecaoNotaCorretagem.ObterNotaAnterior(notaCorretagem.Data);
            List <NotaCorretagem> listaNotasPosteriores = this.ColecaoNotaCorretagem.ObterHistorico(notaAnterior == null ? notaCorretagem.Data : notaAnterior.Data);
            List<MovimentacaoContaCorrente> movimentacaoCC = ColecaoMovimentacaoContaCorrente.ObterHistorico(notaAnterior == null ? notaCorretagem.Data : notaAnterior.Data);

            List<Historico> historico = this.HistoricoServicoDominio.Reconstruir(listaNotasPosteriores, movimentacaoCC);
            ColecaoHistorico.Atualizar(historico);
        }

        public List<NotaCorretagem> ObterNotaCorretagem()
        {
            return this.ColecaoNotaCorretagem.Obter();
        }
    }
}
