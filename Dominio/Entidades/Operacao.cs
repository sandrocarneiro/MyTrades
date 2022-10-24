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
        public string TipoOperacao
        {
            get
            {
                if (this.Descricao.StartsWith("AJUSTE DAY-TRADE"))
                    return "DAYTRADE";
                else if (this.Descricao.StartsWith("BMF - TAXA EMOLUMENTOS"))
                    return "EMOLUMENTOS";
                else if (this.Descricao.StartsWith("BMF - TAXA DE REGISTRO"))
                    return "REGISTRO";
                else if (this.Descricao.StartsWith("IRRF S/ DAY TRADE"))
                    return "IRRF";
                else if (this.Descricao.StartsWith("TED BCO"))
                    return "DEPOSITO";
                else if (this.Descricao.StartsWith("AJUSTE"))
                    return "AJUSTE";
                else
                    return "";
            }
        }
    }
}
