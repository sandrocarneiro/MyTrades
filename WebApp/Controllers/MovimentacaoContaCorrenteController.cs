using Dominio.Entidades;
using Microsoft.AspNetCore.Mvc;
using ServicoAplicacao;
using System;

namespace WebApp.Controllers
{
    public class MovimentacaoContaCorrenteController : Controller
    {
        private MovimentacaoContaCorrenteServico MovimentacaoContaCorrenteServico;
        public MovimentacaoContaCorrenteController()
        {
            this.MovimentacaoContaCorrenteServico = new MovimentacaoContaCorrenteServico();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Inserir()
        {
            MovimentacaoContaCorrente movimentacaoCC = new MovimentacaoContaCorrente()
            {
                Data = new DateTime(2021, 1, 1),
                Valor = 642.61m
            };
            this.MovimentacaoContaCorrenteServico.Inserir(movimentacaoCC);
            return View();
        }
    }
}
