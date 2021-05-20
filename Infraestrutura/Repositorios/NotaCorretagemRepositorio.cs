using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Infraestrutura.Repositorios
{
    public class NotaCorretagemRepositorio
    {
        private string ConnectionString;
        private SqlConnection SqlConn;
        public NotaCorretagemRepositorio()
        {
            this.ConnectionString = "workstation id = mytrade.mssql.somee.com; packet size = 4096; user id = scarneiro_SQLLogin_1; pwd = j9ydgujmxa; data source = mytrade.mssql.somee.com; persist security info = False; initial catalog = mytrade";
        }

        public List<NotaCorretagem> ObterHistorico(DateTime dataInicio)
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NotaCorretagem WHERE Data >= @dataInicio", this.SqlConn);
            cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
            SqlDataReader dr = cmd.ExecuteReader();

            List<NotaCorretagem> lista = new List<NotaCorretagem>();

            while (dr.Read())
            {
                lista.Add(new NotaCorretagem()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Numero = dr["Numero"].ToString(),
                    Data = dr["Data"] == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(dr["Data"].ToString()),
                    ContratosNegociados = int.Parse(dr["ContratosNegociados"].ToString()),
                    AjusteDayTrade = Decimal.Parse(dr["AjusteDayTrade"].ToString()),
                    TaxaRegistro = Decimal.Parse(dr["TaxaRegistro"].ToString()),
                    TaxasBMF = Decimal.Parse(dr["TaxasBMF"].ToString()),
                    TaxaOperacional = Decimal.Parse(dr["TaxaOperacional"].ToString()),
                    IRRF = Decimal.Parse(dr["IRRF"].ToString()),
                    ISS = Decimal.Parse(dr["ISS"].ToString())
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }

        public NotaCorretagem ObterNotaAnterior(DateTime data)
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT TOP 1 * FROM NotaCorretagem WHERE Data < @Data order by Data desc ", this.SqlConn);
            cmd.Parameters.AddWithValue("@Data", data);
            SqlDataReader dr = cmd.ExecuteReader();
        
            if (dr.Read())
            {
                NotaCorretagem nota = new NotaCorretagem()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Numero = dr["Numero"].ToString(),
                    Data = dr["Data"] == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(dr["Data"].ToString()),
                    ContratosNegociados = int.Parse(dr["ContratosNegociados"].ToString()),
                    AjusteDayTrade = Decimal.Parse(dr["AjusteDayTrade"].ToString()),
                    TaxaRegistro = Decimal.Parse(dr["TaxaRegistro"].ToString()),
                    TaxasBMF = Decimal.Parse(dr["TaxasBMF"].ToString()),
                    TaxaOperacional = Decimal.Parse(dr["TaxaOperacional"].ToString()),
                    IRRF = Decimal.Parse(dr["IRRF"].ToString()),
                    ISS = Decimal.Parse(dr["ISS"].ToString())
                };
                dr.Close();
                this.SqlConn.Close();
                return nota;
            }
            else
            {
                dr.Close();
                this.SqlConn.Close();
                return null;
            }
            
        }

        public void Atualizar(List<NotaCorretagem> notasAnteriores)
        {
            throw new NotImplementedException();
        }

        public void Inserir(NotaCorretagem notaCorretagem)
        {
            try
            {
                this.SqlConn = new SqlConnection(ConnectionString);
                this.SqlConn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO NotaCorretagem " +
                    "(Numero, Data, ContratosNegociados, AjusteDayTrade, TaxaRegistro, TaxasBMF, TaxaOperacional, IRRF, ISS) " +
                    "values(" +
                    "@Numero, @Data, @ContratosNegociados, @AjusteDayTrade, @TaxaRegistro, @TaxasBMF, @TaxaOperacional, @IRRF, @ISS)",
                    this.SqlConn);

                cmd.Parameters.AddWithValue("@Numero", notaCorretagem.Numero == null ? DBNull.Value.ToString() : notaCorretagem.Numero);
                cmd.Parameters.AddWithValue("@Data", notaCorretagem.Data);
                cmd.Parameters.AddWithValue("@ContratosNegociados", notaCorretagem.ContratosNegociados);
                cmd.Parameters.AddWithValue("@AjusteDayTrade", notaCorretagem.AjusteDayTrade);
                cmd.Parameters.AddWithValue("@TaxaRegistro", notaCorretagem.TaxaRegistro);
                cmd.Parameters.AddWithValue("@TaxasBMF", notaCorretagem.TaxasBMF);
                cmd.Parameters.AddWithValue("@TaxaOperacional", notaCorretagem.TaxaOperacional);
                cmd.Parameters.AddWithValue("@IRRF", notaCorretagem.IRRF);
                cmd.Parameters.AddWithValue("@ISS", notaCorretagem.ISS);

                cmd.ExecuteNonQuery();
                this.SqlConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NotaCorretagem> Obter()
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NotaCorretagem", this.SqlConn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<NotaCorretagem> lista = new List<NotaCorretagem>();

            while (dr.Read())
            {
                lista.Add(new NotaCorretagem()
                {
                    ID = int.Parse(dr["ID"].ToString()),
                    Numero = dr["Numero"].ToString(),
                    Data = dr["Data"] == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(dr["Data"].ToString()),
                    ContratosNegociados = int.Parse(dr["ContratosNegociados"].ToString()),
                    AjusteDayTrade = Decimal.Parse(dr["AjusteDayTrade"].ToString()),
                    TaxaRegistro = Decimal.Parse(dr["TaxaRegistro"].ToString()),
                    TaxasBMF = Decimal.Parse(dr["TaxasBMF"].ToString()),
                    TaxaOperacional = Decimal.Parse(dr["TaxaOperacional"].ToString()),
                    IRRF = Decimal.Parse(dr["IRRF"].ToString()),
                    ISS = Decimal.Parse(dr["ISS"].ToString())
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }
    }
}
