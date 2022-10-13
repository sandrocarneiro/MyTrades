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
    }
}
