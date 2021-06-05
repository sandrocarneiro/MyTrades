using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models
{
    public class NotaCorretagemViewModel
    {
        public string Numero { get; set; }
        public DateTime Data { get; set; }
        public int ContratosNegociados { get; set; }
        public decimal AjusteDayTrade { get; set; }

        public NotaCorretagemViewModel() { }

        public NotaCorretagem Instanciar()
        {

            return new NotaCorretagem(string.IsNullOrEmpty(this.Numero) ? "" : this.Numero.Trim(),
                                      this.Data,
                                      this.ContratosNegociados,
                                      this.AjusteDayTrade);
        }
    }
}
