using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class ResumoMensalViewModel
    {
        public string ID
        {
            get
            {
                return this.Ano.ToString("D4") + this.Mes.ToString("D2");
            }
        }
        public string Periodo
        {
            get
            {
                switch (this.Mes)
                {
                    case 1:
                        return "Jan/" + this.Ano.ToString();
                    case 2:
                        return "Fev/" + this.Ano.ToString();
                    case 3:
                        return "Mar/" + this.Ano.ToString();
                    case 4:
                        return "Abr/" + this.Ano.ToString();
                    case 5:
                        return "Mai/" + this.Ano.ToString();
                    case 6:
                        return "Jun/" + this.Ano.ToString();
                    case 7:
                        return "Jul/" + this.Ano.ToString();
                    case 8:
                        return "Ago/" + this.Ano.ToString();
                    case 9:
                        return "Set/" + this.Ano.ToString();
                    case 10:
                        return "Out/" + this.Ano.ToString();
                    case 11:
                        return "Nov/" + this.Ano.ToString();
                    case 12:
                        return "Dez/" + this.Ano.ToString();
                    default:
                        return "";
                }
            }
        }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string ValorTotal { get; set; }
        public bool Negativo { get; set; }
        public ResumoMensalViewModel(int ano, int mes, decimal valor)
        {
            this.Ano = ano;
            this.Mes = mes;
            this.ValorTotal = String.Format(new CultureInfo("pt-BR"), "{0:0.00}", valor);
            this.Negativo = valor < 0 ? true : false;
        }

    }
}
