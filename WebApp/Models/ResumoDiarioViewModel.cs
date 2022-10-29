using Dominio.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class ResumoDiarioViewModel
    {
        public DateTime DataOperacao { get; set; }
        public decimal Total { get; set; }
        public List<KeyValuePair<DateTime, string>> PeriodosDistintos { get; set; }
        public List<KeyValuePair<DateTime, decimal>> ResultadosPorDia { get; set; }
        public ResumoDiarioViewModel() { }
        public ResumoDiarioViewModel(List<Operacao> operacoes)
        {
            this.ResultadosPorDia = operacoes.GroupBy(x => x.DataOperacao)
                                             .OrderByDescending(x => x.First().DataOperacao)
                                             .Select(x => new KeyValuePair<DateTime, decimal>(x.First().DataOperacao, x.Sum(y => y.Valor)))
                                             .ToList();


            this.PeriodosDistintos = new List<KeyValuePair<DateTime, string>>();

            DateTime periodo = new DateTime(2016, 1, 1);
            while(periodo <= DateTime.Now)
            {
                var mes = "";
                switch (periodo.Month)
                {
                    case 1:
                        mes = "Jan";
                        break;
                    case 2:
                        mes = "Fev";
                        break;
                    case 3:
                        mes = "Mar";
                        break;
                    case 4:
                        mes = "Abr";
                        break;
                    case 5:
                        mes = "Mai";
                        break;
                    case 6:
                        mes = "Jun";
                        break;
                    case 7:
                        mes = "Jul";
                        break;
                    case 8:
                        mes = "Ago";
                        break;
                    case 9:
                        mes = "Set";
                        break;
                    case 10:
                        mes = "Out";
                        break;
                    case 11:
                        mes = "Nov";
                        break;
                    case 12:
                        mes = "Dez";
                        break;
                };

                PeriodosDistintos.Add(new KeyValuePair<DateTime, string>(new DateTime(periodo.Year, periodo.Month, 1), mes + "/" + periodo.Year.ToString()));
                periodo = periodo.AddMonths(1);
            };
        }
    }
}
