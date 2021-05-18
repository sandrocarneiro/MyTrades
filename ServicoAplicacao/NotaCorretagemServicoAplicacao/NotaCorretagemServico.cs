using Dominio.Entidades;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoAplicacao.NotaCorretagemServicoAplicacao
{
    public class NotaCorretagemServico
    {
        private NotaCorretagemRepositorio ColecaoNotaCorretagem;

        public NotaCorretagemServico()
        {
            this.ColecaoNotaCorretagem = new NotaCorretagemRepositorio();
        }

        public void Inserir(NotaCorretagem notaCorretagem)
        {
            this.ColecaoNotaCorretagem.Inserir(notaCorretagem);
        }

    }
}
