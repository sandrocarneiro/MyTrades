using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Infraestrutura.Repositorios
{
    public class NotaCorretagemRepositorio
    {
        public NotaCorretagemRepositorio() { }

        public void Inserir(NotaCorretagem notaCorretagem)
        {
            try
            {
                string connectionString = "workstation id = mytrade.mssql.somee.com; packet size = 4096; user id = scarneiro_SQLLogin_1; pwd = j9ydgujmxa; data source = mytrade.mssql.somee.com; persist security info = False; initial catalog = mytrade";
                SqlConnection sqlConn = new SqlConnection(connectionString);
                sqlConn.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO NotaCorretagem (Numero, Data, ContratosNegociados, AjusteDayTrade) values(@Numero, @Data, @ContratosNegociados, @AjusteDayTrade)", sqlConn);
                cmd.Parameters.AddWithValue("@Numero", notaCorretagem.Numero);
                cmd.Parameters.AddWithValue("@Data", notaCorretagem.Data);
                cmd.Parameters.AddWithValue("@ContratosNegociados", notaCorretagem.ContratosNegociados);
                cmd.Parameters.AddWithValue("@AjusteDayTrade", notaCorretagem.AjusteDayTrade);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
