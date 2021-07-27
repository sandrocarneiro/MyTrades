using System;
using System.Collections.Generic;
using System.Drawing;
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
            List<NotaCorretagemIndexViewModel> lista = this.NotaCorretagemServico
                                                        .Obter()
                                                        .OrderByDescending(x => x.Data)
                                                        .Select(x => new NotaCorretagemIndexViewModel(x.ID, x.Data, x.Numero, x.ContratosNegociados, x.TotalLiquidoNota))
                                                        .ToList();

            decimal minimo = lista.Min(x => x.TotalLiquidoNota);
            decimal maximo = lista.Max(x => x.TotalLiquidoNota);

            foreach (NotaCorretagemIndexViewModel item in lista)
            {
                item.Cor = HeatMap(item.TotalLiquidoNota, minimo, maximo);
            }

            return View(lista);
        }

        [HttpGet]
        public IActionResult Inserir()
        {
            NotaCorretagemInserirViewModel viewModel = new NotaCorretagemInserirViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Inserir(NotaCorretagemInserirViewModel viewModel)
        {
            try
            {
                this.NotaCorretagemServico.Inserir(viewModel.Instanciar());
                return RedirectToAction("Index", "NotaCorretagem");
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
        public IActionResult Editar(NotaCorretagemEditarViewModel viewModel)
        {
            try
            {
                this.NotaCorretagemServico.Atualizar(viewModel.Instanciar());
                return RedirectToAction("Index", "NotaCorretagem");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public string HeatMap(decimal value, decimal min, decimal max)
        {
            /*
            decimal val = (value - min) / (max - min);
            Color corEspec = Color.FromArgb(Convert.ToByte(255 * (1 - val)), Convert.ToByte(255 * val), 0);
            string hex = "#" + corEspec.R.ToString("X2") + corEspec.G.ToString("X2") + corEspec.B.ToString("X2");
            return hex;
            */

            //decimal mediana = Math.Round(((max - min) / 2) + min, 0);
            //Color corEspec = Color.FromArgb(Convert.ToByte(255 - mediana), Convert.ToByte(255 - mediana), 0);
            //string hex = "#" + corEspec.R.ToString("X2") + corEspec.G.ToString("X2") + corEspec.B.ToString("X2");
            //return hex;


            Color corEspec =  value < 0 ? Color.FromArgb(255, 0, 0) : Color.FromArgb(0, 176, 80);
            string hex = "#" + corEspec.R.ToString("X2") + corEspec.G.ToString("X2") + corEspec.B.ToString("X2");
            return hex;
        }
    }
}
