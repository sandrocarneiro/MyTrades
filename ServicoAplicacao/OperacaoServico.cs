﻿using Dominio.Entidades;
using Infraestrutura.Repositorios;
using System.Collections.Generic;

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
        public List<Operacao> Obter(int ano, int mes)
        {
            return this.ColecaoOperacao.Obter(ano, mes);
        }

        public void Importar(List<string> operacoes)
        {
            this.ColecaoOperacao.Importar(operacoes);
        }
    }
}
