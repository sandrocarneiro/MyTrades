using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class HistoricoRepositorio
    {
        public IUnidadeTrabalho UnidadeTrabalho { get; set; }

        public HistoricoRepositorio()
        {
            this.UnidadeTrabalho = new Contexto();
        }
        public List<Historico> Obter()
        {
            return this.UnidadeTrabalho.CriarColecaoHistorico()
                                        .ToList();
        }
        public void Atualizar(List<Historico> listaHistorico)
        {
            this.UnidadeTrabalho.Atualizar(listaHistorico);
            
        }
    }
}
