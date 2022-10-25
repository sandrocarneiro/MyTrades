using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServicoAplicacao;
using System;
using System.Diagnostics;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private HistoricoServico HistoricoServico;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            this.HistoricoServico = new HistoricoServico();
        }

        public IActionResult Index()
        {
            return View(new HomeIndexViewModel(DateTime.Now.Year, this.HistoricoServico.ObterDadosEstatisticos()));
            //return RedirectToAction("Index", "Operacao");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
