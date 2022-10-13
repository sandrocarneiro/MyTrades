using Microsoft.AspNetCore.Mvc;
using ServicoAplicacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class OperacaoController : Controller
    {
        private OperacaoServico OperacaoServico;

        public OperacaoController()
        {
            this.OperacaoServico = new OperacaoServico();
        }
        public IActionResult Index()
        {
            return View(this.OperacaoServico.Obter()
                                            .OrderByDescending(x => x.DataOperacao)
                                            .Select(x => new OperacaoViewModel(x.ID, x.DataOperacao, x.DataLiquidacao, x.Valor, x.Descricao))
                                            .ToList());
        }



    }
}
