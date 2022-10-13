using Dominio.Entidades;
using Infraestrutura.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServicoAplicacao
{
    public class OperacaoServico
    {
        private OperacaoRepositorio ColecaoOperacao;

        public OperacaoServico()
        {
            this.ColecaoOperacao = new OperacaoRepositorio();
        }

        public List<Operacao> Obter()
        {
            return this.ColecaoOperacao.Obter();
        }

        public void Importar(List<string> operacoes)
        {
            this.ColecaoOperacao.Importar(operacoes);
        }
    }
}
