using Dominio.Entidades;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoAplicacao
{
    public class HistoricoServico
    {
        private HistoricoRepositorio ColecaoHistorico;

        public HistoricoServico()
        {
            this.ColecaoHistorico = new HistoricoRepositorio();
        }

        public List<Historico> ObterNotaCorretagem()
        {
            return this.ColecaoHistorico.Obter();
        }

        internal void Refazer()
        {
            throw new NotImplementedException();
        }
    }
}
