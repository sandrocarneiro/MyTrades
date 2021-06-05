using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;


namespace Infraestrutura.Repositorios
{
    public class NotaCorretagemRepositorio
    {
        public IUnidadeTrabalho UnidadeTrabalho { get; set; }
        public NotaCorretagemRepositorio()
        {
            this.UnidadeTrabalho = new Contexto();
        }

        public List<NotaCorretagem> Obter()
        {
            return this.UnidadeTrabalho.CriarColecaoNotaCorretagem()
                                        .ToList();
        }
        public NotaCorretagem Obter(int id)
        {
            return this.UnidadeTrabalho.CriarColecaoNotaCorretagem()
                                        .Where(x => x.ID == id)
                                        .SingleOrDefault();
        }
        public List<NotaCorretagem> ObterHistorico(DateTime dataInicio)
        {
            return this.UnidadeTrabalho.CriarColecaoNotaCorretagem()
                                        .Where(x => x.Data >= dataInicio)
                                        .ToList();
        }
        public void Inserir(NotaCorretagem notaCorretagem)
        {
            this.UnidadeTrabalho.Inserir(notaCorretagem);
        }

        public void Atualizar(NotaCorretagem nota)
        {
            this.UnidadeTrabalho.Atualizar(nota);
        }
    }
}
