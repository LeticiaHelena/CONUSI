using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Prj_TCC_0._1.Models
{
    public interface IDAO <T> where T: class
    {
        void    Salvar (T obj);
        void    Insert (T obj);
        void    Update (T obj);
        void    Delete (T obj);
        T       Buscar (int id);
        List<T> Listar ();
        List<T> Listar (string pesquisa);
    }
}