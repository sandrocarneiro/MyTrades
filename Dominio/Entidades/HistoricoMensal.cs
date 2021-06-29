using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class HistoricoMensal
    {
        public int Ano { get; set; }
        public int Mes { get; set; }
        public decimal Total { get; set; }
        public int QtdeGanhos { get; set; }
        public int QtdePerdas { get; set; }
        public decimal MediaGanhos { get; set; }
        public decimal MediaPerdas { get; set; }
        public HistoricoMensal(int ano, int mes, decimal total, int qtdeGanhos, int qtdePerdas, decimal mediaGanhos, decimal mediaPerdas)
        {
            this.Ano = ano;
            this.Mes = mes;
            this.Total = total;
            this.QtdeGanhos = qtdeGanhos;
            this.QtdePerdas = qtdePerdas;
            this.MediaGanhos = mediaGanhos;
            this.MediaPerdas = mediaPerdas;
        }
    }
}
