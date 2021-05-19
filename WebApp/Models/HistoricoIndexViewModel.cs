using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HistoricoIndexViewModel
    {
        public List<Historico> ListaHistorico { get; set; }
        public HistoricoIndexViewModel(List<Historico> lista)
        {
            this.ListaHistorico = lista;
        }
    }
}
