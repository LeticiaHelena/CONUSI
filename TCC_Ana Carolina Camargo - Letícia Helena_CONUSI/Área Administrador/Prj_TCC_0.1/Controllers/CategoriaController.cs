using Prj_TCC_0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_TCC_0._1.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult Index(string pesquisa)
        {
            try
            {
                var lst = new CategoriaDAO().Listar(pesquisa);
                return View(lst);
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Falha ao buscar categorias. {0}", ex.Message);
                return View(new List<Categoria>());
            }
        }

        public ActionResult Cadastro()
        {

            return View();
            
        }

        public ActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return View();
            }

            try
            {
                var obj = new CategoriaDAO().Buscar((int)id);
                return View(obj);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Não foi possível buscar essa categoria. {0}", ex.Message);
                return View();
            }

        }

        public ActionResult Salvar(Categoria obj)
        {
            if (!ModelState.IsValid)
            {
                return View("Cadastro", obj);
            }

            try
            {
                new CategoriaDAO().Salvar(obj);
                TempData["SuccessMsg"] = "Categoria salva com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = string.Format("Não foi possível buscar essa categoria. {0}", ex.Message);

            }
            return View("Editar", obj);
        }


        public ActionResult Excluir(int id)
        {
            try
            {
                new CategoriaDAO().Delete(new Categoria { Id = id });
                TempData["SuccessMsg"] = "Categoria excluída com sucesso.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Falha ao excluir essa categoria. {0}", ex.Message);
            }
            return RedirectToAction("Index");
        }

    }
}
