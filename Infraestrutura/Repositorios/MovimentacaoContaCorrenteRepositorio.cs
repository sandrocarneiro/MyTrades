using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class MovimentacaoContaCorrenteRepositorio
    {
        public IUnidadeTrabalho UnidadeTrabalho { get; set; }
        public MovimentacaoContaCorrenteRepositorio()
        {
            this.UnidadeTrabalho = new Contexto();
        }

        public void Inserir(MovimentacaoContaCorrente movimentacaoCC)
        {
            this.UnidadeTrabalho.Inserir(movimentacaoCC);
        }

        public List<MovimentacaoContaCorrente> ObterHistorico(DateTime dataInicio)
        {
            return this.UnidadeTrabalho.CriarColecaoMovimentacaoContaCorrente()
                                        .Where(x => x.Data >= dataInicio)
                                        .ToList();
        }



    }
}
