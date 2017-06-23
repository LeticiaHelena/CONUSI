using Prj_TCC_0._1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Prj_TCC_0._1.Controllers
{
    public class TipoController : Controller
    {
        public ActionResult Index(string pesquisa)
        {
            try
            {
                var lst = new TipoDAO().Listar(pesquisa);
                return View(lst);
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Falha ao buscar tipos. {0}", ex.Message);
                return View(new List<Tipo>());
            }
        }

        public ActionResult Cadastro()
        { 
            ViewBag.Categorias = new CategoriaDAO().Listar();
            return View();

        }

        public ActionResult Editar(int? id)
        {
            ViewBag.Categorias = new CategoriaDAO().Listar();
            
            if (id == null || id == 0)
            {
                return View();
            }

            try
            {
                var obj = new TipoDAO().Buscar((int)id);
                return View(obj);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["ErrorMsg"] = ex.Message;
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Não foi possível buscar esse tipo. {0}", ex.Message);
                return View();
            }

        }

        public ActionResult Salvar(Tipo obj)
        {

             ViewBag.Categorias = new CategoriaDAO().Listar();

             if (ModelState.IsValid)
             {
                 if (string.IsNullOrEmpty(obj.Descricao))
                 {
                     ModelState.AddModelError("", "O campo descrição não pode estar vazio");
                     return View("Cadastro", obj);
                 }
             }

              

            try
            {
               
                new TipoDAO().Salvar(obj);
                TempData["SuccessMsg"] = "Tipo salvo com sucesso!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = string.Format("Não foi possível buscar esse tipo. {0}", ex.Message);

            }
            return View("Editar", obj);
        }


        public ActionResult Excluir(int id)
        {
            try
            {
                new TipoDAO().Delete(new Tipo {IdTipo = id});
                TempData["SuccessMsg"] = "Tipo excluído com sucesso.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMsg"] = String.Format("Falha ao excluir esse tipo. {0}", ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
