using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using ServicoAplicacao;
using WebApp.Models;

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
            List<NotaCorretagemViewModel> lista = this.NotaCorretagemServico
                                                        .Obter()
                                                        .OrderByDescending(x => x.Data)
                                                        .Select(x => new NotaCorretagemViewModel(x.ID, x.Data, x.ContratosNegociados, x.TotalLiquidoNota))
                                                        .ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            NotaCorretagemInserirViewModel viewModel = new NotaCorretagemInserirViewModel();
            viewModel.Data = System.DateTime.Now.ToString("dd/MM/yyyy");
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(NotaCorretagemInserirViewModel viewModel)
        {
            try
            {
                this.NotaCorretagemServico.Inserir(viewModel.Instanciar());
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            return View(new NotaCorretagemDetalheViewModel(this.NotaCorretagemServico.Obter(id)));
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            return View(new NotaCorretagemEditarViewModel(this.NotaCorretagemServico.Obter(id)));
        }

        [HttpPost]
        public IActionResult Editar(NotaCorretagemEditarViewModel nota)
        {
            return View();
        }


    }
}
