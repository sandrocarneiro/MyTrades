using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class HomeIndexViewModel
    {
        public string SaldoCorretoraAtual { get; set; }
        public string SaldoTotalTrades { get; set; }
        public string SaldoMesAtual { get; set; }
        public string MaiorSaldoCorretora { get; set; }
        public string MenorSaldoCorretora { get; set; }

        public List<KeyValuePair<string, string>> TopGain { get; set; }
        public List<KeyValuePair<string, string>> TopLoss { get; set; }

        public HomeIndexViewModel(List<Historico> lista)
        {
            this.SaldoCorretoraAtual = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", lista.OrderByDescending(x => x.Data)
                                             .FirstOrDefault()
                                             .SaldoCorretora);

            this.SaldoTotalTrades = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", lista.Where(x => x.Tipo == "NC")
                                          .Sum(x => x.Valor));

            this.MaiorSaldoCorretora = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", lista.OrderByDescending(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora);

            this.MenorSaldoCorretora = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", lista.OrderBy(x => x.SaldoCorretora)
                                            .FirstOrDefault()
                                            .SaldoCorretora);

            this.TopGain = new List<KeyValuePair<string, string>>();
            foreach (var item in lista.Where(x => x.Tipo == "NC").OrderByDescending(x => x.Valor).Take(3))
            {
                this.TopGain.Add(new KeyValuePair<string, string>(item.Data.ToString(), String.Format(new CultureInfo("pt-BR"), "{0:0.00}", item.Valor)));
            }


            this.TopLoss = new List<KeyValuePair<string, string>>();
            foreach (var item in lista.Where(x => x.Tipo == "NC").OrderBy(x => x.Valor).Take(3))
            {
                this.TopLoss.Add(new KeyValuePair<string, string>(item.Data.ToString(), String.Format(new CultureInfo("pt-BR"), "{0:0.00}", item.Valor)));
            }

        }


    }
}
