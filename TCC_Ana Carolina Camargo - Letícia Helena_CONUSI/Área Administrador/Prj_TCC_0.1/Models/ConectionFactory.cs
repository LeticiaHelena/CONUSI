using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace Prj_TCC_0._1.Models
{
    public class ConectionFactory
    {
        private SqlConnection conn;

        private SqlTransaction tran;

        public ConectionFactory()
        {
            var conex = WebConfigurationManager.ConnectionStrings["ConnConusi"].ConnectionString;
            AbreConexao(conex);
        }

        public ConectionFactory(string conex)
        {
            AbreConexao(conex);
        }

        private void AbreConexao(string conex)
        {
            conn = new SqlConnection
            {
                ConnectionString = conex
            };
            conn.Open();
        }

        private void FechaConexao()
        {
            if (tran != null)
            {
                conn.Close();
                conn.Dispose();
                conn = null;
            }
        }

        public void BeginTran()
        {
            tran = conn.BeginTransaction();
        }


        public void Commit()
        {
            tran.Commit();
            tran = null;
        }

        public void Roolback()
        {
            tran.Rollback();
            tran = null;
        }

        public DataTable ExecutaSpDataTable(string storedProcedure)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            };

            if (tran != null)
            {
                cmd.Transaction = tran;
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds.Tables[0];
        }

        public DataTable ExecutaSpDataTable(string storedProcedure, List<SqlParameter> parametros)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            };

            foreach (var parametro in parametros)
            {
                cmd.Parameters.Add(parametro);
            }

            if (tran != null)
            {
                cmd.Transaction = tran;
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);

            return ds.Tables[0];
        }

        public object ExecutaScalarSp(string storedProcedure, List<SqlParameter> parametros)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            };

            foreach (var parametro in parametros)
            {
                cmd.Parameters.Add(parametro);
            }

            if (tran != null)
            {
                cmd.Transaction = tran;
            }

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();
            da.Fill(ds);

            return cmd.ExecuteScalar();
        }

        public int ExecutaNonQuerySP(string storedProcedure, List<SqlParameter> parametros)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = storedProcedure,
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            };

            foreach (var parametro in parametros)
            {
                cmd.Parameters.Add(parametro);
            }

            if (tran != null)
            {
                cmd.Transaction = tran;
            }

            return cmd.ExecuteNonQuery();
        }
    }
}