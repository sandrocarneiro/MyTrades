using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class OperacaoViewModel
    {
        public string ID { get; set; }
        public string DataOperacao { get; set; }
        public string DataLiquidacao { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public OperacaoViewModel(int id, DateTime dataOperacao, DateTime dataLiquidacao, decimal valor, string descricao)
        {
            this.ID = id.ToString();
            this.DataOperacao = dataOperacao.ToString();
            this.DataLiquidacao = dataLiquidacao.ToString();
            this.Valor = valor.ToString();
            this.Descricao = descricao;
        }
    }
}
