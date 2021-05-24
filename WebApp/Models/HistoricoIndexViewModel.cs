using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HistoricoIndexViewModel
    {
        public List<HistoricoViewModel> ListaHistoricoViewModel { get; set; }
        public HistoricoIndexViewModel(List<Historico> lista)
        {
            this.ListaHistoricoViewModel = lista.Select(x => new HistoricoViewModel(x.Data, x.Tipo, x.Valor, x.SaldoCorretora)).ToList();
        }
    }
}
