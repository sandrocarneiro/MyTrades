using System;

namespace WebApp.Models
{
    public class ResumoDiarioViewModel
    {
        public string DataOperacao { get; set; }
        public string Total { get; set; }
        public ResumoDiarioViewModel()
        {

        }
        public ResumoDiarioViewModel(DateTime dataOperacao, decimal valor)
        {
            this.DataOperacao = dataOperacao.ToString("dd/MM/yyyy");
            this.Total = String.Format("{0: #, ##0.00; (#,##0.00)} ", valor);
        }
    }
}
