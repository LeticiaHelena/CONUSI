using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Prj_TCC_0._1.Models
{
    public class TipoDAO : IDAO<Tipo>
    {
        public void Salvar(Tipo obj)
        {
            if (obj.IdTipo == 0)
                Insert(obj);
            else
                Update(obj);
        }

        public void Insert(Tipo obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Insert_Tipos";

            //Criando lista de parâmetros e inserindo um a um
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_des_tipos", obj.Descricao));
            parametros.Add(new SqlParameter("@p_codpeca_tipo", obj.Categoria.Id));
            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public void Delete(Tipo obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Delete_Tipos";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_tipos", obj.IdTipo));

            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public void Update(Tipo obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Update_Tipos";

            //Criando lista de parâmetros e inserindo um a um
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_tipos", obj.IdTipo));
            parametros.Add(new SqlParameter("@p_des_tipos", obj.Descricao));
            parametros.Add(new SqlParameter("@p_CodPeca_tipos", obj.CodPeca));

            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public Tipo Buscar(int Id)
        {
            var conex = new ConectionFactory();
            string sp = "spBuscarTipos";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_tipos", Id));

            var dt = conex.ExecutaSpDataTable(sp, parametros);

            if (dt.Rows.Count < 1)
                throw new Exception("Tipo não encontrado");

            Tipo tipo = new Tipo(
                int.Parse(dt.Rows[0]["Id_Tipo"].ToString()),
                dt.Rows[0]["Des_Tipo"].ToString(),
                int.Parse(dt.Rows[0]["CodPeca"].ToString())
                );



            //var categoria = new Categoria
            //(
            //    dt.Rows[0]["Des_Tipo"].ToString()
            //);

            return tipo;
        }

        public List<Tipo> Listar()
        {
            var conex = new ConectionFactory();
            string sp = "spListaTipos";

            var dt = conex.ExecutaSpDataTable(sp);
            var tipos = new List<Tipo>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var tipo = new Tipo
                (
                    int.Parse(dt.Rows[i]["Id_Tipo"].ToString()),
                    dt.Rows[i]["Des_Tipo"].ToString()
                );

                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Tipo não encontrado");
                }

                tipos.Add(tipo);
            }
            return tipos;
        }

        public List<Tipo> Listar(string pesquisa)
        {
            var conex = new ConectionFactory();
            string sp = "spListaTipos";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pesquisa", pesquisa));

            var dt = conex.ExecutaSpDataTable(sp, parametros);
            var tipos = new List<Tipo>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var tipo = new Tipo()
                {
                    IdTipo = Convert.ToInt32(dt.Rows[i]["Id_Tipo"]),
                    Descricao = dt.Rows[i]["Des_Tipo"].ToString(),
                    Categoria = new Categoria()
                    {
                        Id = Convert.ToInt32(dt.Rows[i]["CodPeca"]),
                        Descricao = dt.Rows[i]["Des_Categoria"].ToString()
                    }
                };
                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Tipo não encontrado");
                }

                tipos.Add(tipo);
            }
            return tipos;
        }



    }
}