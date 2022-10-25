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
        public List<Historico> ObterNotaCorretagem()
        {
            return this.UnidadeTrabalho.CriarColecaoHistorico()
                                        .Where(x => x.EhNotaCorretagem)
                                        .ToList();
        }

        public List<Historico> ObterHistorico()
        {
            return this.UnidadeTrabalho.CriarColecaoHistorico()
                                        .ToList();
        }
        public List<Historico> ObterNotaCorretagem(string periodo)
        {
            return this.UnidadeTrabalho.CriarColecaoHistorico()
                                        .Where(x => x.EhNotaCorretagem &&
                                                    x.Periodo == periodo)
                                        .ToList();
        }
        public void Atualizar(List<Historico> listaHistorico)
        {
            this.UnidadeTrabalho.Atualizar(listaHistorico);

        }
    }
}
