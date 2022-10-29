using Dominio.Entidades;
using System;
using System.Linq;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class ResumoDiarioViewModel
    {
        public string Periodo { get; set; }
        public decimal Total { get; set; }
        public List<KeyValuePair<DateTime, string>> PeriodosDistintos { get; set; }
        public List<KeyValuePair<DateTime, decimal>> ResultadosPorDia { get; set; }
        public List<int> Anos { get; set; }
        public ResumoDiarioViewModel() { }
        public ResumoDiarioViewModel(int ano, int mes, List<Operacao> operacoes)
        {
            this.ResultadosPorDia = operacoes.GroupBy(x => x.DataOperacao)
                                             .OrderByDescending(x => x.First().DataOperacao)
                                             .Select(x => new KeyValuePair<DateTime, decimal>(x.First().DataOperacao, x.Sum(y => y.Valor)))
                                             .ToList();

            this.Anos = Enumerable.Range(DateTime.Now.Year - 5, 6).ToList();

            this.PeriodosDistintos = new List<KeyValuePair<DateTime, string>>();
            DateTime periodo = new DateTime(2016, 1, 1);
            for (int i = 1; i <= 12; i++)
            {
                var nome_mes = "";
                switch (i)
                {
                    case 1:
                        nome_mes = "Jan";
                        break;
                    case 2:
                        nome_mes = "Fev";
                        break;
                    case 3:
                        nome_mes = "Mar";
                        break;
                    case 4:
                        nome_mes = "Abr";
                        break;
                    case 5:
                        nome_mes = "Mai";
                        break;
                    case 6:
                        nome_mes = "Jun";
                        break;
                    case 7:
                        nome_mes = "Jul";
                        break;
                    case 8:
                        nome_mes = "Ago";
                        break;
                    case 9:
                        nome_mes = "Set";
                        break;
                    case 10:
                        nome_mes = "Out";
                        break;
                    case 11:
                        nome_mes = "Nov";
                        break;
                    case 12:
                        nome_mes = "Dez";
                        break;
                };

                PeriodosDistintos.Add(new KeyValuePair<DateTime, string>(new DateTime(ano, i, 1), nome_mes));
                periodo = periodo.AddMonths(1);
            };


            var mes_periodo = "";
            switch (mes)
            {
                case 1:
                    mes_periodo = "Jan";
                    break;
                case 2:
                    mes_periodo = "Fev";
                    break;
                case 3:
                    mes_periodo = "Mar";
                    break;
                case 4:
                    mes_periodo = "Abr";
                    break;
                case 5:
                    mes_periodo = "Mai";
                    break;
                case 6:
                    mes_periodo = "Jun";
                    break;
                case 7:
                    mes_periodo = "Jul";
                    break;
                case 8:
                    mes_periodo = "Ago";
                    break;
                case 9:
                    mes_periodo = "Set";
                    break;
                case 10:
                    mes_periodo = "Out";
                    break;
                case 11:
                    mes_periodo = "Nov";
                    break;
                case 12:
                    mes_periodo = "Dez";
                    break;
            };
            this.Periodo = mes_periodo + "/" + ano.ToString();

        }
    }
}
