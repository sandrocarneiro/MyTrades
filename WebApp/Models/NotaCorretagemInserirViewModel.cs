namespace WebApp.Models
{
    public class NotaCorretagemInserirViewModel : NotaCorretagemViewModel
    {
        public NotaCorretagemInserirViewModel()
        {
            this.Data = System.DateTime.Now;
            this.ContratosNegociados = 2;
        }
    }
}
