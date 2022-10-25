using System;

namespace WebApp.Models
{
    public class OperacaoViewModel
    {
        public string ID { get; set; }
        public string DataOperacao { get; set; }
        public string DataLiquidacao { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public string TipoOperacao { get; set; }
        public OperacaoViewModel(int id, DateTime dataOperacao, DateTime dataLiquidacao, decimal valor, string descricao, string tipo)
        {
            this.ID = id.ToString();
            this.DataOperacao = dataOperacao.ToString("dd/MM/yyyy");
            this.DataLiquidacao = dataLiquidacao.ToString("dd/MM/yyyy");
            this.TipoOperacao = tipo;
            this.Valor = String.Format("{0: #, ##0.00; (#,##0.00)} ", valor);
            this.Descricao = descricao;
        }
    }
}
