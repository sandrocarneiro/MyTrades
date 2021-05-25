using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using ServicoAplicacao;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HistoricoController : Controller
    {
        private HistoricoServico HistoricoServico;

        public HistoricoController()
        {
            this.HistoricoServico = new HistoricoServico();
        }
        public IActionResult Index()
        {
            try
            {
                List<Historico> lista = this.HistoricoServico.Obter().OrderByDescending(x => x.Data).ToList();
                HistoricoIndexViewModel viewModel = new HistoricoIndexViewModel(lista);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
