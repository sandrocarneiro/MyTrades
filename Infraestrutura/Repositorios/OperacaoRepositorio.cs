using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class OperacaoRepositorio
    {
        public IUnidadeTrabalho UnidadeTrabalho { get; set; }
        public OperacaoRepositorio()
        {
            this.UnidadeTrabalho = new Contexto();
        }
        public List<Operacao> Obter()
        {
            return this.UnidadeTrabalho.CriarColecaoOperacao()
                       .ToList();
        }
        public List<Operacao> ObterPorAno(int ano)
        {
            return this.UnidadeTrabalho.CriarColecaoOperacao()
                       .Where(x => x.DataOperacao.Year == ano)
                       .ToList();
        }

        public void Importar(List<string> operacoes)
        {
            List<DateTime> datasOperacoes = new List<DateTime>();
            foreach (string operacao in operacoes.Skip(1).ToList())
            {
                var campos = operacao.Split(";");
                datasOperacoes.Add(Convert.ToDateTime(campos[0]));
            }
            this.UnidadeTrabalho.DeletarOperacoes(datasOperacoes.Distinct().ToList());

            foreach (string operacao in operacoes.Skip(1).ToList())
            {
                var campos = operacao.Split(";");
                this.UnidadeTrabalho.InserirOperacao(Convert.ToDateTime(campos[0]), Convert.ToDateTime(campos[1]), Convert.ToDecimal(campos[2]), campos[3]);
            }
        }
    }
}
