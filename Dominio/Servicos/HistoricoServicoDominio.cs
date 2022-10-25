using Dominio.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Dominio.Servicos
{
    public class HistoricoServicoDominio
    {
        public List<Historico> Reconstruir(List<NotaCorretagem> listaNotasPosteriores,
                                           List<MovimentacaoContaCorrente> movimentacaoCC)
        {
            List<Historico> historico = listaNotasPosteriores
                                            .Select(x => new Historico { Data = x.Data, Tipo = "NC", Valor = x.TotalLiquidoNota })
                                            .ToList();

            historico.AddRange(movimentacaoCC.Select(x => new Historico { Data = x.Data, Tipo = "CC", Valor = x.Valor })
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
