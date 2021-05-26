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
        public IActionResult ResumoMensal()
        {
            try
            {
                List<Historico> lista = this.HistoricoServico.Obter().OrderByDescending(x => x.Data).ToList();
                var visaoMensal = lista.GroupBy(x => new { x.Data.Year, x.Data.Month })
                                        .Select(g => new ResumoMensalViewModel(g.Key.Year, g.Key.Month, g.Sum(s => s.Valor)))
                                        .OrderByDescending(x => x.Ano).ThenByDescending(x => x.Mes)
                                        .ToList();
                return View(visaoMensal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult ResumoDiario(string id)
        {
            try
            {
                List<Historico> lista = this.HistoricoServico.Obter(id).OrderByDescending(x => x.Data).ToList();
                ResumoDiarioViewModel viewModel = new ResumoDiarioViewModel(lista);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
