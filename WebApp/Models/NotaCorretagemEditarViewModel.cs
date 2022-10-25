using Dominio.Entidades;

namespace WebApp.Models
{
    public class NotaCorretagemEditarViewModel : NotaCorretagemViewModel
    {
        public int ID { get; set; }
        public NotaCorretagemEditarViewModel() { }
        public NotaCorretagemEditarViewModel(NotaCorretagem nota)
        {
            this.ID = nota.ID;
            this.Data = nota.Data;
            this.Numero = nota.Numero;
            this.ContratosNegociados = nota.ContratosNegociados;
            this.AjusteDayTrade = nota.AjusteDayTrade;
        }
        public NotaCorretagem Instanciar()
        {
            return new NotaCorretagem(this.ID,
                                      string.IsNullOrEmpty(this.Numero) ? "" : this.Numero.Trim(),
                                      this.Data,
                                      this.ContratosNegociados,
                                      this.AjusteDayTrade.Value);
        }
    }
}
