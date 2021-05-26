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
        public List<Historico> Obter(string periodo)
        {
            return this.ColecaoHistorico.Obter(periodo);
        }

        public List<Historico> Obter()
        {
            return this.ColecaoHistorico.Obter();
        }
    }
}
