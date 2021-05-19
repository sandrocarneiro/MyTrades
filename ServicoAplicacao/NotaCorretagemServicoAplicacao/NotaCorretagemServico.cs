using Dominio.Entidades;
using Dominio.Servicos;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoAplicacao.NotaCorretagemServicoAplicacao
{
    public class NotaCorretagemServico
    {
        private NotaCorretagemRepositorio ColecaoNotaCorretagem;
        private MovimentacaoContaCorrenteRepositorio ColecaoMovimentacaoContaCorrente;
        private MovimentacaoContaCorrenteServico MovimentacaoContaCorrenteServico;

        public NotaCorretagemServico()
        {
            this.ColecaoNotaCorretagem = new NotaCorretagemRepositorio();
            this.ColecaoMovimentacaoContaCorrente = new MovimentacaoContaCorrenteRepositorio();
            this.MovimentacaoContaCorrenteServico = new MovimentacaoContaCorrenteServico();
        }

        public void Inserir(NotaCorretagem notaCorretagem)
        {            
            this.ColecaoNotaCorretagem.Inserir(notaCorretagem);
            List<NotaCorretagem> notasAnteriores = this.ColecaoNotaCorretagem.ObterNotasAnteriores(notaCorretagem.Data);
            List<MovimentacaoContaCorrente> movimentacaoCC = this.ColecaoMovimentacaoContaCorrente.ObterMovimentacoesContaCorrenteAnteriores(notaCorretagem.Data);
            this.MovimentacaoContaCorrenteServico.AtualizarSaldoCorretora(notasAnteriores, movimentacaoCC);
            this.ColecaoNotaCorretagem.Atualizar(notasAnteriores);
            this.ColecaoMovimentacaoContaCorrente.Atualizar(movimentacaoCC);
        }

        public List<NotaCorretagem> ObterNotaCorretagem()
        {
            return this.ColecaoNotaCorretagem.Obter();
        }
    }
}
