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
        private MovimentacaoContaCorrenteRepositorio ColecaoMovimentacaoContaCorrente;
        private MovimentacaoContaCorrenteServico MovimentacaoContaCorrenteServico;
        private HistoricoServico ColecaoHistorico;

        public NotaCorretagemServico()
        {
            this.ColecaoNotaCorretagem = new NotaCorretagemRepositorio();
            this.ColecaoHistorico = new HistoricoServico();
        }

        public void Inserir(NotaCorretagem notaCorretagem)
        {            
            this.ColecaoNotaCorretagem.Inserir(notaCorretagem);
            this.ColecaoHistorico.Refazer();
        }

        public List<NotaCorretagem> ObterNotaCorretagem()
        {
            return this.ColecaoNotaCorretagem.Obter();
        }
    }
}
