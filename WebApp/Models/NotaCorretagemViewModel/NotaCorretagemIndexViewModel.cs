using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;


namespace WebApp.Models.NotaCorretagemViewModel
{
    public class NotaCorretagemIndexViewModel
    {
        public List<NotaCorretagem> ListaNotaCorretagem;

        public NotaCorretagemIndexViewModel(List<NotaCorretagem> lista)
        {
            this.ListaNotaCorretagem = lista;
        }
    }
}
