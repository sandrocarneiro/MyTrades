﻿using System;
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
                NotaCorretagem nota1 = new NotaCorretagem() { ID = 1, Data = System.DateTime.Now, Numero = "123", ContratosNegociados = 2, AjusteDayTrade = 100 };
                NotaCorretagem nota2 = new NotaCorretagem() { ID = 2, Data = System.DateTime.Now, Numero = "456", ContratosNegociados = 4, AjusteDayTrade = -20 };
                List<NotaCorretagem> lista = new List<NotaCorretagem>();
                lista.Add(nota1);
                lista.Add(nota2);
                NotaCorretagemIndexViewModel viewModel = new NotaCorretagemIndexViewModel(lista);
                return View(viewModel);
            }
            catch (Exception)
            {
                throw;
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
                NotaCorretagem nota = viewModel.Instanciar();
                this.NotaCorretagemServico.Inserir(nota);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
