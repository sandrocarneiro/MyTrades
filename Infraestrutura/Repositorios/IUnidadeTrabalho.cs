using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
        void Atualizar(NotaCorretagem nota);

    }
}
