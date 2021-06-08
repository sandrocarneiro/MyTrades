﻿using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace Infraestrutura.Repositorios
{
    public class Contexto : IUnidadeTrabalho
    {
        private string ConnectionString;
        private SqlConnection SqlConn;

        public Contexto()
        {
            this.ConnectionString = "workstation id = mytrade.mssql.somee.com; packet size = 4096; user id = scarneiro_SQLLogin_1; pwd = j9ydgujmxa; data source = mytrade.mssql.somee.com; persist security info = False; initial catalog = mytrade";
        }

        #region Historico
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

        public List<Historico> CriarColecaoHistorico()
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
                    Data = this.ObterDatetime(dr["Data"]),
                    Valor = this.ObterDecimal(dr["Valor"]),
                    Tipo = this.ObterString(dr["Tipo"]),
                    SaldoCorretora = this.ObterDecimal(dr["SaldoCorretora"])
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }
        #endregion

        #region MovimentacaoContaCorrente
        public List<MovimentacaoContaCorrente> CriarColecaoMovimentacaoContaCorrente()
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM MovimentacaoContaCorrente", this.SqlConn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<MovimentacaoContaCorrente> lista = new List<MovimentacaoContaCorrente>();

            while (dr.Read())
            {
                lista.Add(new MovimentacaoContaCorrente()
                {
                    ID = this.ObterInteger(dr["ID"]),
                    Data = this.ObterDatetime(dr["Data"]),
                    Valor = this.ObterDecimal(dr["Valor"])
                });
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
        }
        public void Inserir(MovimentacaoContaCorrente movimentacaoCC)
        {
            try
            {
                this.SqlConn = new SqlConnection(ConnectionString);
                this.SqlConn.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO MovimentacaoContaCorrente " +
                    "(Data, Valor) " +
                    "values(" +
                    "@Data, @Valor)",
                    this.SqlConn);

                cmd.Parameters.AddWithValue("@Data", movimentacaoCC.Data);
                cmd.Parameters.AddWithValue("@Valor", movimentacaoCC.Valor);
                cmd.ExecuteNonQuery();
                this.SqlConn.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region NotaCorretagem
        public List<NotaCorretagem> CriarColecaoNotaCorretagem()
        {
            this.SqlConn = new SqlConnection(ConnectionString);
            this.SqlConn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM NotaCorretagem", this.SqlConn);
            SqlDataReader dr = cmd.ExecuteReader();

            List<NotaCorretagem> lista = new List<NotaCorretagem>();

            while (dr.Read())
            {
                lista.Add(new NotaCorretagem(
                                            this.ObterInteger(dr["ID"]),
                                            this.ObterDatetime(dr["Data"]),
                                            this.ObterString(dr["Numero"]),
                                            this.ObterInteger(dr["ContratosNegociados"]),
                                            this.ObterDecimal(dr["AjusteDayTrade"]),
                                            this.ObterDecimal(dr["TaxaRegistro"]),
                                            this.ObterDecimal(dr["TaxasBMF"]),
                                            this.ObterDecimal(dr["TaxaOperacional"]),
                                            this.ObterDecimal(dr["IRRF"]),
                                            this.ObterDecimal(dr["ISS"])
                                             )
                          );
            }
            dr.Close();
            this.SqlConn.Close();
            return lista;
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
                cmd.Parameters.AddWithValue("@Data", notaCorretagem.DataFormatoUniversal);
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
        public void Atualizar(NotaCorretagem notaCorretagem)
        {
            try
            {
                this.SqlConn = new SqlConnection(ConnectionString);
                this.SqlConn.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE NotaCorretagem " +
                    "SET " +
                    " Numero = @Numero, " +
                    " Data = @Data, " +
                    " ContratosNegociados = @ContratosNegociados, " +
                    " AjusteDayTrade = @AjusteDayTrade, " +
                    " TaxaRegistro = @TaxaRegistro, " +
                    " TaxasBMF = @TaxasBMF, " +
                    " TaxaOperacional = @TaxaOperacional, " +
                    " IRRF = @IRRF, " +
                    " ISS = @ISS " +
                    "WHERE ID = @id ",
                    this.SqlConn);

                cmd.Parameters.AddWithValue("@ID", notaCorretagem.ID);
                cmd.Parameters.AddWithValue("@Numero", notaCorretagem.Numero == null ? DBNull.Value.ToString() : notaCorretagem.Numero);
                cmd.Parameters.AddWithValue("@Data", notaCorretagem.DataFormatoUniversal);
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
        #endregion

        #region Métodos Privados
        private DateTime ObterDatetime(object valor)
        {
            return valor == System.DBNull.Value ? new DateTime() : Convert.ToDateTime(valor.ToString());
        }
        private decimal ObterDecimal(object valor)
        {
            return valor.ToString() == "" ? 0 : Decimal.Parse(valor.ToString());
        }
        private int ObterInteger(object valor)
        {
            return valor == System.DBNull.Value ? 0 : int.Parse(valor.ToString());
        }
        private string ObterString(object valor)
        {
            return valor == System.DBNull.Value ? "" : valor.ToString();
        }
        #endregion
    }
}
