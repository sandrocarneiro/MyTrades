using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using ServicoAplicacao.NotaCorretagemServicoAplicacao;
using WebApp.Models.NotaCorretagemViewModel;

namespace WebApp.Controllers
{
    public class NotaCorretagemController : Controller
    {
        private NotaCorretagemServico NotaCorretagemServico;

        public NotaCorretagemController()
        {
            this.NotaCorretagemServico = new NotaCorretagemServico();
        }

        public IActionResult Index()
        {
            try
            {
                List<NotaCorretagem> lista = this.NotaCorretagemServico.ObterNotaCorretagem();
                NotaCorretagemIndexViewModel viewModel = new NotaCorretagemIndexViewModel(lista);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult Inserir()
        {
            NotaCorretagemInserirViewModel viewModel = new NotaCorretagemInserirViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inserir(NotaCorretagemInserirViewModel viewModel)
        {
            try
            {
                this.NotaCorretagemServico.Inserir(viewModel.Instanciar());
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
