using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Operacao
    {
        public Operacao() { }

        public Operacao(int id, DateTime dataOperacao, DateTime dataLiquidacao, decimal valor, string descricao)
        {
            this.ID = id;
            this.DataOperacao = dataOperacao;
            this.DataLiquidacao = dataLiquidacao;
            this.Valor = valor;
            this.Descricao = descricao;
        }

        public int ID { get; set; }
        public DateTime DataOperacao { get; set; }
        public DateTime DataLiquidacao { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public decimal SaldoFinal { get; set; }
    }
}
