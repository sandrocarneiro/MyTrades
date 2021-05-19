using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Infraestrutura.Repositorios
{
    public class MovimentacaoContaCorrenteRepositorio
    {
        private string ConnectionString;
        private SqlConnection SqlConn;
        public MovimentacaoContaCorrenteRepositorio()
        {
            this.ConnectionString = "workstation id = mytrade.mssql.somee.com; packet size = 4096; user id = scarneiro_SQLLogin_1; pwd = j9ydgujmxa; data source = mytrade.mssql.somee.com; persist security info = False; initial catalog = mytrade";
        }

        public List<MovimentacaoContaCorrente> ObterMovimentacoesContaCorrenteAnteriores(DateTime data)
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MovimentacaoContaCorrente", this.SqlConn);
            //cmd.Parameters.AddWithValue("@Data", data);
            // ToDo: otimizar retornando apenas a partir da nota anterior
            SqlDataReader dr = cmd.ExecuteReader();

            List<MovimentacaoContaCorrente> lista = new List<MovimentacaoContaCorrente>();

            while (dr.Read())
            {
                lista.Add(new MovimentacaoContaCorrente()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Data = dr["Data"] == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(dr["Data"].ToString()),
                    Valor = int.Parse(dr["Valor"].ToString()),
                    SaldoCorretora = dr["SaldoCorretora"].ToString() == "" ? 0 : Decimal.Parse(dr["SaldoCorretora"].ToString())
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }

        public void Atualizar(List<MovimentacaoContaCorrente> movimentacaoCC)
        {
            throw new NotImplementedException();
        }
    }
}
