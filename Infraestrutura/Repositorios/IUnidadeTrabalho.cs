using Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Infraestrutura.Repositorios
{
    public interface IUnidadeTrabalho
    {
        List<NotaCorretagem> CriarColecaoNotaCorretagem();
        List<Historico> CriarColecaoHistorico();
        List<MovimentacaoContaCorrente> CriarColecaoMovimentacaoContaCorrente();
        List<Operacao> CriarColecaoOperacao();
        void Atualizar(List<Historico> listaHistorico);
        void Inserir(NotaCorretagem notaCorretagem);
        void Inserir(MovimentacaoContaCorrente movimentacaoCC);
        void InserirOperacao(DateTime dataOperacao, DateTime dataLiquidacao, Decimal valor, String descricao);
        void Atualizar(NotaCorretagem nota);
        void DeletarOperacoes(List<DateTime> dateTimes);
    }
}
