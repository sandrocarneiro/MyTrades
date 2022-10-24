using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicoAplicacao;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
                                            .OrderByDescending(x => x.DataOperacao )
                                            .Select(x => new OperacaoViewModel(x.ID, x.DataOperacao, x.DataLiquidacao, x.Valor, x.Descricao, x.TipoOperacao))
                                            .ToList());
        }
        [HttpPost("FileUpload")]
        public async Task<IActionResult> Importar(IFormFile arquivo)
        {
            List<string> operacoes = new List<string>();

            using (var reader = new StreamReader(arquivo.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                    operacoes.Add(reader.ReadLine());
            }
            this.OperacaoServico.Importar(operacoes);
            return RedirectToAction("Index");
        }

        public IActionResult ResumoDiario()
        {
            return View(this.OperacaoServico.Obter()
                                            .GroupBy(x => x.DataOperacao)
                                            .OrderByDescending(x => x.First().DataOperacao)
                                            .Select(x => new ResumoDiarioViewModel(x.First().DataOperacao, x.Sum(y => y.Valor)))
                                            .ToList()
                                            );

        }
    }
}
