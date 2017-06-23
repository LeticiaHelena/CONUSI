using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
namespace Prj_TCC_0._1.Models
{
    public class PecaDAO: IDAO<Peca>
    {
        public void Salvar(Peca obj)
        {
            if (obj.Id == 0)
                Insert(obj);
            else
                Update(obj);
        }

        public void Insert(Peca obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Insert_Pecas";

            //Criando lista de parâmetros e inserindo um a um
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_CodConusi_pecas", obj.CodConusi));
            parametros.Add(new SqlParameter("@p_CodTipo_pecas", obj.Tipo.IdTipo));
            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public void Delete(Peca obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Delete_Pecas";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_pecas", obj.Id));

            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public void Update(Peca obj)
        {
            var conex = new ConectionFactory();
            string sp = "sp_Update_Pecas";

            //Criando lista de parâmetros e inserindo um a um
            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_pecas", obj.Id));
            parametros.Add(new SqlParameter("@p_CodConusi_pecas", obj.CodConusi));
            parametros.Add(new SqlParameter("@p_CodTipo_pecas", obj.Tipo.IdTipo));

            conex.ExecutaNonQuerySP(sp, parametros);
        }

        public Peca Buscar(int id)
        {
            var conex = new ConectionFactory();
            string sp = "spBuscarPecas";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@p_id_pecas", id));

            var dt = conex.ExecutaSpDataTable(sp, parametros);

            if (dt.Rows.Count < 1)
                throw new Exception("Peça não encontrada");

            var peca = new Peca
            (
                
            );

            dt.Rows[0]["CodConusi"].ToString();
            

            return peca;
        }

        public List<Peca> Listar()
        {
            var conex = new ConectionFactory();
            string sp = "spListaPecas";

            var dt = conex.ExecutaSpDataTable(sp);
            var pecas = new List<Peca>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var peca = new Peca();

                dt.Rows[i]["CodConusi"].ToString();
                dt.Rows[i]["CodTipo"].ToString(); 
                


                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Peça não encontrada");
                }

                pecas.Add(peca);
            }
            return pecas;
        }

        public List<Peca> Listar(string pesquisa)
        {
            var conex = new ConectionFactory();
            string sp = "spListaPecas";

            var parametros = new List<SqlParameter>();
            parametros.Add(new SqlParameter("@pesquisa", pesquisa));

            var dt = conex.ExecutaSpDataTable(sp, parametros);
            var pecas = new List<Peca>();

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var peca = new Peca()
                {
                    Id = int.Parse(dt.Rows[i]["Id"].ToString()),
                    CodConusi = dt.Rows[i]["CodConusi"].ToString(),
                    Tipo = new Tipo()
                    {
                        IdTipo = int.Parse(dt.Rows[i]["CodTipo"].ToString()),
                        Descricao = dt.Rows[i]["Des_Tipo"].ToString()
                    }
                };

                if (dt.Rows.Count < 1)
                {
                    throw new Exception("Peça não encontrada");
                }

                pecas.Add(peca);
            }
            return pecas;
        }



    }
}