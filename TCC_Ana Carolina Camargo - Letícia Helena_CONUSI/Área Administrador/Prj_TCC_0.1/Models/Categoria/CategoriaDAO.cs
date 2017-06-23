using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace Prj_TCC_0._1.Models
{
    public class CategoriaDAO : IDAO<Categoria>  
    {
        public void Salvar(Categoria obj)
        {
            if (obj.Id == 0)
                Insert(obj);
            else
                Update(obj);
        }

        public void Insert(Categoria obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Insert_Categoria";

            //Criando lista de parâmetros e inserindo um a um
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_des_categoria", obj.Descricao));
            obj.Id = (int)conex.ExecutaScalarSp(sp, parametros);
        }

        public void Delete(Categoria obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Delete_Categoria";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_categoria", obj.Id));

            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public void Update(Categoria obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Update_Categoria";

            //Criando lista de parâmetros e inserindo um a um
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_categoria", obj.Id));
            parametros.Add(new SqlParameter("@p_des_categoria", obj.Descricao));

            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public Categoria Buscar(int id)
        {
            var conex = new ConectionFactory();
            string sp = "spBuscarCategoria";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_categoria", id));


            var dt = conex.ExecutaSpDataTable(sp, parametros);

            if (dt.Rows.Count < 1)
                throw new Exception("Categoria não encontrada");

            var categoria = new Categoria
            (
                int.Parse(dt.Rows[0]["Id_Categoria"].ToString()),
                dt.Rows[0]["Des_Categoria"].ToString()
            );

            return (Categoria)categoria;
        }

        public List<Categoria> Listar()
        {
            var conex = new ConectionFactory();
            string sp = "spListaCategoria";

            var dt = conex.ExecutaSpDataTable(sp);
            var categorias = new List<Categoria>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var categoria = new Categoria
                (
                    int.Parse(dt.Rows[i]["Id_Categoria"].ToString()),
                    dt.Rows[i]["Des_Categoria"].ToString()
                );


                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Categoria não encontrada");
                }

                categorias.Add(categoria);
            }
            return categorias;
        }

        public List<Categoria> Listar(string pesquisa)
        {
            var conex = new ConectionFactory();
            string sp = "spListaCategoria";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pesquisa", pesquisa));

            var dt = conex.ExecutaSpDataTable(sp, parametros);
            var categorias = new List<Categoria>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var categoria = new Categoria
                    (
                       int.Parse(dt.Rows[i]["Id_Categoria"].ToString()),
                       dt.Rows[i]["Des_Categoria"].ToString()
                    );


                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Categoria não encontrada");
                }

                categorias.Add(categoria);
            }
            return categorias;
        }

    }
}