using System;

namespace WebApp.Models
{
    public class ResumoDiarioViewModel
    {
        public DateTime DataOperacao { get; set; }
        public decimal Total { get; set; }
        public ResumoDiarioViewModel()
        {

        }
        public ResumoDiarioViewModel(DateTime dataOperacao, decimal valor)
        {
            this.DataOperacao = dataOperacao;
            this.Total = valor;
        }
    }
}
