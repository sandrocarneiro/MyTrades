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


        public List<MovimentacaoContaCorrente> ObterHistorico(DateTime dataInicio)
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MovimentacaoContaCorrente WHERE Data >= @dataInicio", this.SqlConn);
            cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
            SqlDataReader dr = cmd.ExecuteReader();

            List<MovimentacaoContaCorrente> lista = new List<MovimentacaoContaCorrente>();

            while (dr.Read())
            {
                lista.Add(new MovimentacaoContaCorrente()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Data = dr["Data"] == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(dr["Data"].ToString()),
                    Valor = Decimal.Parse(dr["Valor"].ToString())
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }

    }
}
