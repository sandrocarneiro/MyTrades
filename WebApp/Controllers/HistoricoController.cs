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
                List<HistoricoMensal> historicoMensal = this.HistoricoServico.ObterDadosEstatisticosPorMes();
                List<ResumoMensalViewModel> retorno = historicoMensal.Select(x => new ResumoMensalViewModel(x .Ano, 
                                                                                                            x.Mes, 
                                                                                                            x.Total,
                                                                                                            x.QtdeGanhos, 
                                                                                                            x.QtdePerdas, 
                                                                                                            x.MediaGanhos, 
                                                                                                            x.MediaPerdas))
                                                                     .ToList();
                return View(retorno);


                //List<Historico> lista = this.HistoricoServico.ObterNotaCorretagem().OrderByDescending(x => x.Data).ToList();
                //var visaoMensal = lista.GroupBy(x => new { x.Data.Year, x.Data.Month })
                //                        .Select(g => new ResumoMensalViewModel(g.Key.Year, g.Key.Month, g.Sum(s => s.Valor)))
                //                        .OrderByDescending(x => x.Ano).ThenByDescending(x => x.Mes)
                //                        .ToList();
                //return View(visaoMensal);
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
                List<Historico> lista = this.HistoricoServico.ObterNotaCorretagem(id).OrderByDescending(x => x.Data).ToList();
                var visaoMensal = new ResumoDiarioViewModel(lista);
                return View(visaoMensal);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
