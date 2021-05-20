using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dominio.Servicos
{
    public class HistoricoServicoDominio
    {
        public List<Historico> Reconstruir(List<NotaCorretagem> listaNotasPosteriores,
                                           List<MovimentacaoContaCorrente> movimentacaoCC)
        {
            List<Historico> historico = listaNotasPosteriores
                                            .Select(x => new Historico { Data = x.Data, Valor = x.TotalLiquidoNota })
                                            .ToList();
            
            historico.AddRange(movimentacaoCC.Select(x => new Historico { Data = x.Data, Valor = x.Valor })
                                             .ToList());

            decimal saldo = 0;
            foreach (Historico nota in historico.OrderBy(x => x.Data))
            {
                saldo += nota.Valor;
                nota.SaldoCorretora = saldo;
            }

            return historico.ToList().OrderBy(x => x.Data).ToList();
        }
    }
}
