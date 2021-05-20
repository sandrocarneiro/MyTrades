using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Infraestrutura.Repositorios
{
    public class HistoricoRepositorio
    {
        private string ConnectionString;
        private SqlConnection SqlConn;

        public HistoricoRepositorio()
        {
            this.ConnectionString = "workstation id = mytrade.mssql.somee.com; packet size = 4096; user id = scarneiro_SQLLogin_1; pwd = j9ydgujmxa; data source = mytrade.mssql.somee.com; persist security info = False; initial catalog = mytrade";
        }
        public List<Historico> Obter()
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM Historico", this.SqlConn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<Historico> lista = new List<Historico>();

            while (dr.Read())
            {
                lista.Add(new Historico()
                {
                    Data = dr["Data"] == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(dr["Data"].ToString()),
                    Valor = Decimal.Parse(dr["Valor"].ToString()),
                    SaldoCorretora = dr["SaldoCorretora"].ToString() == "" ? 0 : Decimal.Parse(dr["SaldoCorretora"].ToString())
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }
        public void Atualizar(List<Historico> listaHistorico)
        {
            try
            {
                this.SqlConn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("delete from Historico", this.SqlConn);
                this.SqlConn.Open();
                cmd.ExecuteNonQuery();

                foreach (Historico item in listaHistorico)
                {
                    cmd = new SqlCommand("INSERT INTO Historico (Data, Tipo, Valor, SaldoCorretora) " +
                                         "values(@Data, @Tipo, @Valor, @SaldoCorretora)", this.SqlConn);
                    cmd.Parameters.AddWithValue("@Data", item.Data);
                    cmd.Parameters.AddWithValue("@Tipo", item.Tipo);
                    cmd.Parameters.AddWithValue("@Valor", item.Valor);
                    cmd.Parameters.AddWithValue("@SaldoCorretora", item.SaldoCorretora);
                    cmd.ExecuteNonQuery();
                }
                this.SqlConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
